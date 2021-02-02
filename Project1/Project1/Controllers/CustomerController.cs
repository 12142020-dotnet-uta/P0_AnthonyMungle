using BusinessLogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{

    /// <summary>
    /// Main Controller for customer and stores
    /// </summary>
    public class CustomerController : Controller
    {

        private BusinessLogicClass _businessLogicClass;
        public CustomerController(BusinessLogicClass businessLogicClass)
        {
            this._businessLogicClass = businessLogicClass;
        }



        /*  // GET: CustomerController
          public ActionResult Index()
          {
              return View();
          }

          // GET: CustomerController/Details/5
          public ActionResult Details(int id)
          {
              return View();
          }

          // GET: CustomerController/Create
          public ActionResult Create()
          {
              return View();
          }

          // POST: CustomerController/Create
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
          }*/

        /// <summary>
        /// Returns the user to main Display
        /// </summary>
        /// <param name="customerGuid"></param>
        /// <returns></returns>
        public ActionResult ReturnToMain(Guid customerGuid)
        {
            CustomerViewModel customerViewModel = _businessLogicClass.EditCustomer(customerGuid);
            return View("DisplayCustomerDetails", customerViewModel);

        }

        /// <summary>
        /// Edits customersViewModel from a user GUID
        /// </summary>
        /// <param name="customerGuid"></param>
        /// <returns></returns>
        // GET: CustomerController/Edit/5
        [Route("{customerGuid}")]
        public ActionResult EditCustomer(Guid customerGuid)
        {
            CustomerViewModel customerViewModel = _businessLogicClass.EditCustomer(customerGuid);

            return View(customerViewModel);
        }

        /// <summary>
        /// Allows the editView to actually edit a CustomerViewModel
        /// then returns the DisplayUserVIew
        /// </summary>
        /// <param name="customerViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("EditedCustomer")]
        public ActionResult EditCustomer(CustomerViewModel customerViewModel)
        {
            CustomerViewModel customerViewModel1 = _businessLogicClass.EditedCustomer(customerViewModel);
            return View("DisplayCustomerDetails", customerViewModel1);
        }

        /// <summary>
        /// Retrieves the locationList view
        /// </summary>
        /// <param name="customerGuid"></param>
        /// <returns></returns>
        [ActionName("StartLocationMenu")]
        public IActionResult LocationList(Guid customerGuid)
        {
            List<LocationViewModel> locationViewModelList = _businessLogicClass.LocationList(customerGuid);
            return View("LocationList", locationViewModelList);
        }

        /// <summary>
        /// Retrieves the InventoryList view
        /// </summary>
        /// <param name="InventoryList"></param>
        /// <param name="customerGuid"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult InventoryList(int InventoryList, Guid customerGuid)//passes guid up to here
        {
            List<InventoryViewModel> inventoryViewModels = _businessLogicClass.SearchInventoryList(InventoryList, customerGuid);
            return View("InventoryList", inventoryViewModels);
        }

        /// <summary>
        /// Brings up the AddToCartView which is the
        /// Details for Products
        /// </summary>
        /// <param name="LocationId"></param>
        /// <param name="InventoryId"></param>
        /// <param name="productName"></param>
        /// <param name="customerGuid"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddingToCart(int LocationId, int InventoryId, string productName, Guid customerGuid)//Gets all the necessary values from here
        {
            AmountToAddViewModel amountToAddViewModel = _businessLogicClass.AmountToAdd(LocationId, InventoryId, productName, customerGuid);
            return View("AddToCart", amountToAddViewModel);
        }

        /// <summary>
        /// Checks to see if the user has selected enough or too many products
        /// from the list of available stock
        /// </summary>
        /// <param name="amountToAddView"></param>
        /// <returns></returns>
        public IActionResult CanBeAdded(AmountToAddViewModel amountToAddView)
        {
            if (amountToAddView.amount > amountToAddView.stock)
            {
                ModelState.AddModelError("Failure", "The amount you chose exceeded stock");
                return View("AddToCart", amountToAddView);
            }

            if (amountToAddView.amount != 0)
            {
                ModelState.AddModelError("Success", "Item(s) added to cart");
                _businessLogicClass.AddToCart(amountToAddView);
                _businessLogicClass.SubtractFromInventory(amountToAddView.inventory, amountToAddView.amount);
            }
            List<InventoryViewModel> inventoryViewModels = _businessLogicClass.SearchInventoryList(amountToAddView.location, amountToAddView.CustomerId);
            return View("InventoryList", inventoryViewModels);
        }

        /// <summary>
        /// Brings up the cart view
        /// </summary>
        /// <param name="customerGuid"></param>
        /// <returns></returns>
        public ActionResult ViewCart(Guid customerGuid)
        {
            List<CartViewModel> cartViewModelList = _businessLogicClass.cartViewModel(customerGuid);
            return View("ViewCart", cartViewModelList);
        }

        /// <summary>
        /// Deletes the selected cart then brings up the displayCustomerDetails view
        /// </summary>
        /// <param name="CartId"></param>
        /// <param name="customerGuid"></param>
        /// <returns></returns>
        public ActionResult DeleteCartItem(Guid CartId, Guid customerGuid)
        {
            _businessLogicClass.DeleteCartItem(CartId);
            //List<CartViewModel> cartViewModelList = _businessLogicClass.cartViewModel(customerGuid);
            ModelState.AddModelError("Delete", "your items have been Deleted");
            CustomerViewModel customerViewModel = _businessLogicClass.EditCustomer(customerGuid);
            return View("DisplayCustomerDetails", customerViewModel);
        }

        public ActionResult OrderNow(Guid cartId, Guid customerGuid)
        {
            _businessLogicClass.OrderNow(cartId);
            ModelState.AddModelError("Order", "Your Order has been placed");
            CustomerViewModel customerViewModel = _businessLogicClass.EditCustomer(customerGuid);
            return View("DisplayCustomerDetails", customerViewModel);
        }

        public ActionResult ViewOrders(int LocationId, Guid CustomerId)
        {

            List<OrderViewModel> orderViewModel = _businessLogicClass.ViewOrderHistory(LocationId, CustomerId);

            return View("ViewOrders", orderViewModel);
        }

       /* // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
        }*/
    }
}
