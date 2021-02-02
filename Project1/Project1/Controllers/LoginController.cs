using BusinessLogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers//Controller, Business/ repo through the constructors //DependencyInjection
{
    public class LoginController : Controller
    {
        private BusinessLogicClass _businessLogicClass;
        public LoginController(BusinessLogicClass businessLogicClass)
        {
            _businessLogicClass = businessLogicClass;
        }

        public ActionResult Login()
        {
            return View();
        }

        // GET: Login
        //[ActionName("Login")]
        [ActionName("LoginView")]
        public ActionResult Login(LoginViewModel logIn)
        {
               if (ModelState.IsValid)
              {
                //need to update it to see if the username is unique
                CustomerViewModel customerViewModel = _businessLogicClass.LogInCustomerUsingUsername(logIn);
                  if (customerViewModel == null)
                  {
                      ModelState.AddModelError("Failure", "This username does NOT exist! Please create a user");
                      return View();
                  }

                  return View("DisplayCustomerDetails", customerViewModel);
              }
              else
              {
                return View();
              }
        }

        [ActionName("CreateCustomer")]
        public ActionResult Login(CreateCustomerViewModel CreateCustomerViewModel)
        {//loginCustomerViewModel
            if (ModelState.IsValid)
            {
                //need to update it to see if the username is unique
                CustomerViewModel customerViewModel = _businessLogicClass.LogInCustomer(CreateCustomerViewModel);
                if (customerViewModel == null)
                {
                    ModelState.AddModelError("Failure", "This username is already taken");
                    return View("login");
                }

                return View("DisplayCustomerDetails", customerViewModel);
            }
            else
            {
                return View(CreateCustomerViewModel);
            }
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
