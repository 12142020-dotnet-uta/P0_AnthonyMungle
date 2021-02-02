using Microsoft.AspNetCore.Http;
using ModelLayer;
using ModelLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    /// <summary>
    /// Handles the Conversoins of
    /// information
    /// </summary>
    public class Mapper
    {

        /// <summary>
        /// Converts a customer object to a CustomerViewModel
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public CustomerViewModel convertToCustomerViewModel(Customer customer)
        {
            CustomerViewModel customerViewModel = new CustomerViewModel()
            {
                CustomerId = customer.CustomerId,
                Fname = customer.Fname,
                Lname = customer.Lname,
                Uname = customer.Uname,
                JpgString = ConvertByteArrayToString(customer.ByteArrayImage)
            };

            return customerViewModel;

        }

        /// <summary>
        /// Converts a location object and customer Guid
        /// into a LocationViewModel
        /// </summary>
        /// <param name="location"></param>
        /// <param name="customerGuid"></param>
        /// <returns></returns>
        public LocationViewModel convertToLocationViewModel(Location location, Guid customerGuid)
        {
            LocationViewModel locationViewModel = new LocationViewModel()
            {
                CustomerId = customerGuid,
                LocationId = location.LocationId,
                LocationName = location.LocationName
                
            };

            return locationViewModel;

        }

        /// <summary>
        /// Converts Product object to ProductViewModel
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ProductModelView convertToProductModelView(Product product)
        {
            ProductModelView productModelView = new ProductModelView()
            {
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                JpgString = ConvertByteArrayToString(product.ByteArrayImage)
            };

            return productModelView;
        }

        /// <summary>
        /// Converts an inventory into an inventory view model
        /// </summary>
        /// <param name="inventory"></param>
        /// <param name="customerGuid"></param>
        /// <returns></returns>
        public InventoryViewModel convertToInventoryModelView(Inventory inventory, Guid customerGuid)
        {
            InventoryViewModel inventoryViewModel = new InventoryViewModel()
            {
                LocationId = inventory.Location.LocationId,
                CustomerId = customerGuid,
                InventoryId = inventory.InventoryId,
                ProductName = inventory.Product.ProductName,
                Quantity = inventory.Quantity,
                ProductPicture = ConvertByteArrayToString(inventory.Product.ByteArrayImage),
                price = inventory.Product.Price
            };

            return inventoryViewModel;
        }

        /// <summary>
        /// converts a Cart object into a CartViewModel
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public CartViewModel ConvertToCartViewModel(Cart cart)
        {
            CartViewModel cartViewModel = new CartViewModel()
            {
                customerGuid = cart.Owner.CustomerId,
                locationsId = cart.location,
                CartId = cart.CartId,
                ProductName = cart.Product.ProductName,
                total = cart.Product.Price * cart.amount              
            };

            return cartViewModel;
        }

        /// <summary>
        /// Converts an Order Object to an OrderViewModel
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public OrderViewModel ConvertToOrderViewModel(Order order)
        {
            OrderViewModel orderViewModel = new OrderViewModel()
            {
                Amount = order.Amount,
                Date = order.Date,
                Price = order.Price,
                OrderId = order.OrderId,
                ProductName = order.ProductName
            };

            return orderViewModel;

        }


        /// <summary>
        /// Converts a picter byte[] into a string
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public string ConvertByteArrayToString(byte[] byteArray)
        {
            if (byteArray != null)
			{
				string imageBase64Data = Convert.ToBase64String(byteArray, 0, byteArray.Length);
				string imageDataURL = string.Format($"data:image/jpg;base64,{imageBase64Data}");
				return imageDataURL;
			}
			else return null;
        }

        /// <summary>
        /// converts to an IformFile
        /// </summary>
        /// <param name="iformFile"></param>
        /// <returns></returns>
        public byte[] ConvertIformFileToByteArray(IFormFile iformFile)
        {
            if (iformFile != null)
            {
                using (var ms = new MemoryStream())
                {
                    iformFile.CopyTo(ms);

                    if (ms.Length > 2097152)
                    {
                        return null;
                    }
                    else
                    {
                        byte[] a = ms.ToArray();
                        return a;
                    }
                }
            }
            return null;
        }

    }
}
