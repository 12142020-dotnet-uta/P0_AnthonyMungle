using ModelLayer;
using ModelLayer.ViewModels;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{ 
    /// <summary>
    /// Handles the main functions and code of the project
    /// </summary>
    public class BusinessLogicClass
    {
        private readonly Repository _repository;
        private readonly Mapper _mapper;
        public BusinessLogicClass(Repository repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Takes a Login playerViewModel instance and returns a playerViewModel instance
        /// </summary>
        /// <returns></returns>
        public CustomerViewModel LogInCustomer(CreateCustomerViewModel loginCustomerViewModel)
        {
            Customer customer = new Customer()
            {
                Fname = loginCustomerViewModel.Fname,
                Lname = loginCustomerViewModel.Lname,
                Uname = loginCustomerViewModel.Uname
            };

            Customer currentCustomer = _repository.LogInCustomer(customer);
            if(currentCustomer != null)
            {
                CustomerViewModel customerViewModel = _mapper.convertToCustomerViewModel(currentCustomer);
                return customerViewModel;
            }
            return null;

            
        }

        /// <summary>
        /// Takes a customer Guid and tranforms it into a view model
        /// </summary>
        /// <param name="customerGuid"></param>
        /// <returns></returns>
        public CustomerViewModel EditCustomer(Guid customerGuid)
        {
            Customer customer = _repository.GetCustomerById(customerGuid);
            CustomerViewModel customerViewModel = _mapper.convertToCustomerViewModel(customer);
            return customerViewModel;

        }

        /// <summary>
        /// Takes a customer view Model and transforms into another one 
        /// with the given variables inside the parameter
        /// </summary>
        /// <param name="customerViewModel"></param>
        /// <returns></returns>
        public CustomerViewModel EditedCustomer(CustomerViewModel customerViewModel)
        {
            Customer customer = _repository.GetCustomerById(customerViewModel.CustomerId);

            customer.Fname = customerViewModel.Fname;
            customer.Lname = customerViewModel.Lname;
            customer.Uname = customerViewModel.Uname;
            customer.ByteArrayImage = _mapper.ConvertIformFileToByteArray(customerViewModel.IformFileImage);

            Customer customer1 = _repository.EditCustomer(customer);

            CustomerViewModel customerViewModel1 = _mapper.convertToCustomerViewModel(customer1);

            return customerViewModel1;

        }

        /// <summary>
        /// Retrieves a list of available locations
        /// </summary>
        /// <param name="customerGuid"></param>
        /// <returns></returns>
        public List<LocationViewModel> LocationList(Guid customerGuid)
        {

            List<Location> locationList = _repository.LocationList();

            List<LocationViewModel> locationViewModelList = new List<LocationViewModel>();
            foreach(Location L in locationList)
            {
                locationViewModelList.Add(_mapper.convertToLocationViewModel(L, customerGuid));
            }

            return locationViewModelList;

        }

        /// <summary>
        /// Retreives a list of Inventories using the location iD
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="customerGuid"></param>
        /// <returns></returns>
        public List<InventoryViewModel> SearchInventoryList(int locationId, Guid customerGuid)
        {
            List<Inventory> inventoryList = _repository.SearchInventoryList(locationId);
            List<InventoryViewModel> inventoryViewModel = new List<InventoryViewModel>();

            foreach(Inventory I in inventoryList)
            {
               
                inventoryViewModel.Add(_mapper.convertToInventoryModelView(I, customerGuid));

            }
            return inventoryViewModel;
        }

        /// <summary>
        /// Creates a customerViewModel from a LogInViewMOdel
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public CustomerViewModel LogInCustomerUsingUsername(LoginViewModel user)
        {
            string username = user.Uname;
            Customer currentCustomer = _repository.LogInCustomerWithUserName(username);
            if (currentCustomer != null)
            {
                CustomerViewModel customerViewModel = _mapper.convertToCustomerViewModel(currentCustomer);
                return customerViewModel;
            }
            return null;

        }

        /// <summary>
        /// Determines the amount of items to add to a AMountToAddViewModel using the parameter listed
        /// 
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="inventoryId"></param>
        /// <param name="productName"></param>
        /// <param name="customerGuid"></param>
        /// <returns></returns>
        public AmountToAddViewModel AmountToAdd(int locationId, int inventoryId, string productName, Guid customerGuid)
        {
            // Cart currentCart = _repository.GetCart(customerGuid);
            Product product = new Product();
            product = _repository.GetProduct(productName);
            byte[] picture = product.ByteArrayImage;
            int amountTotal = _repository.GetInventoryStock(inventoryId);

            AmountToAddViewModel addToCartViewModel = new AmountToAddViewModel()
            {
                stock = amountTotal,
                location = locationId,
                CustomerId = customerGuid,
                inventory = inventoryId,
                Product = productName,
                discription = product.Description
                
            };
            if(picture != null)
            {
                addToCartViewModel.JpgString = _mapper.ConvertByteArrayToString(picture);
            }
            return addToCartViewModel;
        }

        /// <summary>
        /// Throws an AmountToAddViewModel to the repository
        /// </summary>
        /// <param name="amountToAddViewModel"></param>
        public void AddToCart(AmountToAddViewModel amountToAddViewModel)
        {
            _repository.AddToCart(amountToAddViewModel);
        }

        /// <summary>
        /// Throws two variables to the repository SubtractFromInventory
        /// </summary>
        /// <param name="inventoryId"></param>
        /// <param name="amount"></param>
        public void SubtractFromInventory(int inventoryId, int amount)
        {
            _repository.SubtractFromInventory(inventoryId, amount);
        }

        /// <summary>
        /// Returns a list of CartViewModels
        /// </summary>
        /// <param name="customerGuid"></param>
        /// <returns></returns>
        public List<CartViewModel> cartViewModel(Guid customerGuid)
        {
             List<Cart> cartList = _repository.SearchCartList(customerGuid);
            List<CartViewModel> cartViewModelList = new List<CartViewModel>();
            foreach(Cart C in cartList)
            {
                cartViewModelList.Add(_mapper.ConvertToCartViewModel(C));
            }
            return cartViewModelList;
          
        }

        /// <summary>
        /// Throws a cart Guid to the repository
        /// </summary>
        /// <param name="cartId"></param>
        public void OrderNow(Guid cartId)
        {
            _repository.OrderNow(cartId);
        }

        /// <summary>
        /// throws a cartGuid to the rpositry
        /// </summary>
        /// <param name="cartId"></param>
        public void DeleteCartItem(Guid cartId)
        {
            _repository.DeleteCart(cartId);
        }


        /// <summary>
        /// returns a list of OrderViewMOdeles
        /// Act as the Locations History
        /// </summary>
        /// <param name="LocationId"></param>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public List<OrderViewModel> ViewOrderHistory(int LocationId, Guid CustomerId)
        {
            List<Order> order = _repository.SearchOrderList(LocationId);
            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();//_repository.ViewOrderHistory(LocationId, CustomerId);
            foreach(Order O in order)
            {

                orderViewModels.Add(_mapper.ConvertToOrderViewModel(O));

            }
            return orderViewModels;
        }

    }
}
