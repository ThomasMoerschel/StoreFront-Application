using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SAWebUI.Models;
using StoreAppBL;
using StoreAppModels;
using Serilog;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAWebUI.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerBL _custBL;
        private IStoreFrontBL _storeBL;
        private IInventoryBL _invBL;
        private IOrderBL _ordBL;
        public CustomerController(ICustomerBL p_custBL, IStoreFrontBL p_storeBL, IInventoryBL p_invBL, IOrderBL p_ordBL)
        {
            _custBL = p_custBL;
            _storeBL = p_storeBL;
            _invBL = p_invBL;
            _ordBL = p_ordBL;
        }
        public IActionResult Index()
        {
            Log.Information("Displaying List of Customers in Database");
            return View(
                _custBL.GetAllCustomers()
                .Select(cust => new CustomerVM(cust))
                .ToList()
            );
        }
        public IActionResult Add()
        {
            Log.Information("Manager Adding Customer");
            return View();
        }
        public IActionResult StoreFrontMenu()
        {
            Log.Information("Displaying All StoreFronts");
            return View(
                _storeBL.GetAllStoreFronts()
                .Select(store => new StoreFrontVM(store))
                .ToList());
        }
        public IActionResult StoreInventory(int p_storeID)
        {
            Log.Information("Displaying Selected Store Inventory");
            return View(
                _invBL.GetInventory(p_storeID)
                .Select(inv => new LineItemsVM(inv))
                .ToList()
            );
        }
        public IActionResult ViewCustomerOrderHistory(int p_customerID)
        {
            Log.Information("Displaying Order History of Customer");
            Customer customerOrders = new Customer();
            customerOrders.Id = p_customerID;
            var orders = _ordBL.GetOrders(customerOrders)
                .Select(ord => new OrdersVM(ord))
                .ToList();
            foreach (var ord in orders)
            {
                ord.Price = Math.Round(ord.Price, 2);
            }
            return View(orders);

        }
        public IActionResult ViewStoreOrderHistory(int p_storeID, string sortOrder)
        {
            Log.Information("Displaying the Order History of a StoreFront");
            ViewBag.storeID = p_storeID;
            var orders = _ordBL.GetOrders(p_storeID)
                        .Select (ord =>new OrdersVM(ord))
                        .ToList();
            foreach (var ord in orders)
            {
                ord.Price = Math.Round(ord.Price, 2);
            }
            switch (sortOrder)
                {
                    case "orders_Desc":
                        Log.Information("Sorting Orders by Descending Price");
                        orders = orders.OrderByDescending(ord=>ord.Price)
                                .ToList();
                        break;
                    case "orders_Asc":
                        Log.Information("Sorting Orders Price by Ascending");
                        orders = orders.OrderBy(ord=>ord.Price)
                                .ToList();
                        break;
                    default:
                        break;
                }
                return View(orders);
        }
        [HttpPost]
        public IActionResult Index(string custName)
        {
            Log.Information("Searching by Customer Name");
            var match = _custBL.GetAllCustomers()
                        .Select(cust => new CustomerVM(cust))
                        .ToList();
            List<CustomerVM> searchCustomer = new List<CustomerVM>();
            foreach (CustomerVM cust in match)
            {
                if (custName == null){
                    Log.Information("Customer Not Found, Displaying all customers");
                    searchCustomer = match;
                }
                else if (cust.Name.ToUpper().Contains(custName.ToUpper()))
                {
                    Log.Information("Customer(s) Found, Displaying Results");
                    searchCustomer.Add(cust);
                }
                
            }
            return View(searchCustomer);
        }
        [HttpPost]
        public IActionResult StoreInventory(LineItemsVM item)
        {
            Log.Information("Adding Inventory to a store");
               int storeID = item.storeID;
               _invBL.AddInventory(new LineItems
                {
                    ProductsId = item.ProductsId,
                    Product = item.Product,
                    Id = item.Id,
                    storeId = item.storeID,
                }, item.Quantity);
            Log.Information("Redirecting to Store Inventory to view change");
            return RedirectToAction("StoreInventory", "Customer", new{p_storeID = storeID});
        }
        [HttpPost]
        public IActionResult Add(CustomerVM custVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Log.Information("Adding a customer to Database");
                    _custBL.AddCustomer(new Customer
                        {
                        Name = custVM.Name,
                        PhoneNumber = custVM.PhoneNumber,
                        Email = custVM.Email,
                        Address = custVM.Address,
                        Password = custVM.Password,
                        }
                    );
                    Log.Information("Redirecting to Customer List");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                Log.Information("ModelState is Invalid");
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
