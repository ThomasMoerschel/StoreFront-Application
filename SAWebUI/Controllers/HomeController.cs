
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SAWebUI.Models;
using StoreAppBL;
using StoreAppModels;
using Serilog;

namespace SAWebUI.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerBL _custBL;
        private IStoreFrontBL _storeBL;
        private IInventoryBL _invBL;
        private IProductsBL _proBL;
        private IOrderBL _ordBL;
        public static List <LineItemsVM> cart = new List<LineItemsVM>();
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, ICustomerBL p_custBL, IStoreFrontBL p_storeBL, IInventoryBL p_invBL, IProductsBL p_proBL, IOrderBL p_ordBL)
        {
            _logger = logger;
            _custBL = p_custBL;
            _storeBL = p_storeBL;
            _invBL = p_invBL;
            _proBL = p_proBL;
            _ordBL = p_ordBL;
        }
        public IActionResult Index()
        {
            Log.Information("Customer Login");
            return View();
        }
        public IActionResult ManagerMenu()
        {
            Log.Information("Manager Menu");
            return View();
        }
        public IActionResult ManagerLogin()
        {
            Log.Information("Manager Login");
            return View();
        }
        public IActionResult OrderThanks()
        {
            Log.Information("Order Confirmation");
            return View();
        }
        /// <summary>
        /// Takes in store ID and CustomerID and loops through static class cart, finds prices from list of products, adds them together
        /// outputs list of items with the price to view 
        /// NOTE: order has not been committed to database here
        /// </summary>
        /// <param name="p_id"></param>
        /// <param name="p_customerID"></param>
        /// <returns>A view with cart items and total price</returns>
        public IActionResult MakeAnOrder(int p_id, int p_customerID)
        {
            Log.Information("MakeAnOrder Reached");
            TempData["stoID"] = p_id;
            ViewBag.custID = p_customerID;
            var prod = _proBL.GetProducts(p_id)
                        .Select(pro => new ProductsVM(pro))
                        .ToList();
            Orders newOrder = new Orders();
            foreach (ProductsVM pro in prod)
            {
                foreach (LineItemsVM item in cart)
                {
                    if (item.Product == pro.Name)
                    {
                        newOrder.Price += (pro.Price * item.Quantity);
                    }
                }
            }
            newOrder.Price = Math.Round(newOrder.Price, 2);
            TempData["Price"] = newOrder.Price;
            return View(cart);
        }
        public IActionResult Add()
        {
            Log.Information("Add New Customer");
            return View();
        }
        public IActionResult StoreFrontMenu(int customerID)
        {
            Log.Information("StoreFront Menu");
            ViewBag.customerID = customerID;
            return View(
                _storeBL.GetAllStoreFronts()
                .Select(store => new StoreFrontVM(store))
                .ToList()
            );
        }
        public IActionResult StoreInventory(int p_id, int p_customerID)
        {
            Log.Information("Store Inventory reached");
            ViewBag.custID = p_customerID;
            return View(
                _invBL.GetInventory(p_id)
                .Select(inv => new LineItemsVM(inv))
                .ToList()
            );
        }
        /// <summary>
        /// Takes user input from, essentially, the order confirmation screen. It takes in the custID and storeID to compile an order and commit it to database
        /// if requested. Also takes in param "cancelOrder" which determines whether to cancel order, clear cart, and add inventory items back OR add a new order
        /// </summary>
        /// <param name="p_id"></param>
        /// <param name="p_customerID"></param>
        /// <param name="cancelOrder"></param>
        /// <returns>Either brings user to order confirmation or cancels order and logs the user out</returns>
        [HttpPost]
        public IActionResult MakeAnOrder(int p_id, int p_customerID, string cancelOrder)
        {
            Log.Information("Make An Order HTTP Post");
            if (cancelOrder == "OrderCancelled")
            {
                Log.Information("Order Cancelled");
                foreach (LineItemsVM items in cart)
                {
                    _invBL.AddInventory(new LineItems
                    {
                        Id = items.Id,
                        Quantity = items.Quantity,
                        Product = items.Product,
                        storeId = items.storeID,
                    }, items.Quantity);
                }
                cart.Clear();
                return RedirectToAction(nameof(Index));
            }
            else if (cancelOrder == "Checkout")
            {
                Log.Information("Order Checkout");
                Orders newOrder = new Orders();
                var prod = _proBL.GetProducts(p_id)
                        .Select(pro => new ProductsVM(pro))
                        .ToList();
                foreach (ProductsVM pro in prod)
                {
                    foreach (LineItemsVM item in cart)
                    {
                    if (item.Product == pro.Name)
                        {
                        newOrder.Price += (pro.Price * item.Quantity);
                        }
                    }
                }
            _ordBL.AddOrder(p_id, p_customerID, newOrder);
            cart.Clear();
            return RedirectToAction(nameof(OrderThanks));
            }
            else{
                Log.Information("Checkout Requested, Displaying Order Details");
                return RedirectToAction("MakeAnOrder", "Home", new {p_id = p_id, p_customerID = p_customerID});
            }
        }
        /// <summary>
        /// From manager login, validates the data and either admits or rejects manager access
        /// </summary>
        /// <param name="managerLogin"></param>
        /// <returns> Manger menu's if valid, Manager Login if login info is invalid</returns>
        [HttpPost]
        public IActionResult ManagerLogin(CustomerVM managerLogin)
        {
             try
            {
                if (ModelState.IsValid)
                {
                    Log.Information("Validifying Manager Credentials");
                    var test = _custBL.GetCustomer(new Customer
                            {
                            Name = managerLogin.Name,
                            Address = managerLogin.Address,
                            PhoneNumber = managerLogin.PhoneNumber,
                            Email = managerLogin.Email,
                            Password = managerLogin.Password,
                            Manager = managerLogin.Manager,
                            }
                        );
                    if (test.Name == "Invalid Entry" || test.Manager == 0)
                    {
                        Log.Information("Manager Login Rejected");
                        return RedirectToAction(nameof(ManagerLogin));
                    }
                    else
                    {
                        Log.Information("Manager Login Accepted");
                        return RedirectToAction("Index", "Customer");
                    }
                }
            }
            catch (Exception)
            {
                Log.Information("Manager Login: Model State Not Valid");
                return View();
            }
            return View();
        }
        /// <summary>
        /// Customer admits themselves as a new user in the database
        /// </summary>
        /// <param name="custVM"></param>
        /// <returns>Returns to login screen after sign up</returns>
        [HttpPost]
        public IActionResult Add(CustomerVM custVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Log.Information("Adding a New Customer");
                    _custBL.AddCustomer(new Customer
                        {
                        Name = custVM.Name,
                        PhoneNumber = custVM.PhoneNumber,
                        Email = custVM.Email,
                        Address = custVM.Address,
                        Password = custVM.Password,
                        }
                    );
                    Log.Information("Redirecting to Cusotmer Login Screen");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                Log.Information("Customer Login ModelState is not Valid");
                return View();
            }
            return View();
        }
        /// <summary>
        /// Validifies customer details and either brings them to storefront menu, or back to login if invalid
        /// </summary>
        /// <param name="custVM"></param>
        /// <returns>Storefront menu or Customer Login</returns>
        [HttpPost]
        public IActionResult Index(CustomerVM custVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Log.Information("Validifying Customer Credentials");
                    var test = _custBL.GetCustomer(new Customer
                            {
                            Name = custVM.Name,
                            Address = custVM.Address,
                            PhoneNumber = custVM.PhoneNumber,
                            Email = custVM.Email,
                            Password = custVM.Password,
                            Id = custVM.Id,
                            }
                        );
                    if (test.Name == "Invalid Entry")
                    {
                        Log.Information("Customer Not Found, Redirecting to Customer Login");
                        return RedirectToAction(nameof(Index));
                    }
                    else{
                        Log.Information("Customer Found! Redirecting to StoreFront Menu");
                        return RedirectToAction("StoreFrontMenu", "Home", new {customerID = test.Id});
                        }
                }
            }
            catch (Exception)
            {
                Log.Information("Customer Validation ModelState is Invalid");
                return View();
            }
            return View();
        }
        /// <summary>
        /// Takes in cartItem, checks if it exists in cart: (if, adds quantity to existing cart item; else, adds new cart item) and returns user back to storeinventory screen to make another selection
        /// Takes in customerID to persist data
        /// "cancelOrder" string determines when to exit this loop
        /// </summary>
        /// <param name="cartItem"></param>
        /// <param name="_customerID"></param>
        /// <param name="cancelOrder"></param>
        /// <returns>Back to store inventory to make another selection. This loop stops once string "cancelOrder" conditionals are reached</returns>
        [HttpPost]
        public IActionResult StoreInventory(LineItemsVM cartItem, int _customerID, string cancelOrder)
        {
            Log.Information("Store Inventory Response");
            if (cancelOrder == "OrderCancelled")
            {
                Log.Information("Order has been Cancelled!");
                Log.Information("Adding Cart Inventory Back to Store, Logging out");
                foreach (LineItemsVM items in cart)
                {
                    _invBL.AddInventory(new LineItems
                    {
                        Id = items.Id,
                        Quantity = items.Quantity,
                        Product = items.Product,
                        storeId = items.storeID,
                    }, items.Quantity);
                }
                cart.Clear();
                return RedirectToAction(nameof(Index));
            }
            else{
            Log.Information("Adding Items to Cart");
            ViewBag.custID = _customerID;
            TempData["stoID"] = cartItem.storeID;
            int itemAmount = 0;
            bool found = false;
            if (cart.Count > 0)
            {
                for (int i = 0; i<cart.Count; i++)
                {
                    if (cart[i].Product == cartItem.Product)
                    {
                        Log.Information("Item Found in Cart, Increasing Cart Quantity");
                        cart[i].Quantity += cartItem.Quantity;
                        found = true;
                    }
                }
                if (found == false)
                {
                    Log.Information("Unique Item Added to Cart");
                    cart.Add(cartItem);
                }
            }
            else {
                Log.Information("Cart Empty, Adding Unique Item");
                cart.Add(cartItem);
            }
            itemAmount = cartItem.Quantity - (cartItem.Quantity * 2);
            Log.Information("Subtracting Cart Item Quanitty from Inventory Item Quantity");
            _invBL.AddInventory(new LineItems
                {
                    Id = cartItem.Id,
                    Quantity = cartItem.Quantity,
                    Product = cartItem.Product,
                    storeId = cartItem.storeID,
                }
                , itemAmount);
            Log.Information("Returning to StoreInventory to Add Another Cart Item");
            return RedirectToAction("StoreInventory", "Home", new {p_id = cartItem.storeID, p_customerID = _customerID});
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            Log.Information("Generic Error Method Reached");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
