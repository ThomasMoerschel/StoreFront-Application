using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StoreAppModels;

namespace StoreAppDL
{
    public class Repository : IRepository
    {
        private StoreAppDBContext _context;
        public Repository(StoreAppDBContext p_context)
        {
            _context = p_context;
        }
        public Customer AddCustomer(Customer p_customer)
        {
            _context.Customers.Add(p_customer);
            _context.SaveChanges();
            return p_customer;
        }

        public LineItems AddInventory(LineItems p_lineItems, int quantity)
        {
            var lineItem = _context.LineItems.Select(item => item).ToList();
            foreach (LineItems item in lineItem)
            {
                if (item.Product == p_lineItems.Product)
                {
                    item.Quantity = item.Quantity + quantity;
                    _context.LineItems.Update(item);
                    
                }
            }
             _context.SaveChanges();
             return p_lineItems;                         
        }

        public Orders AddOrder(int storeID, int customerID, Orders p_order)
        {
            p_order.StoreId = storeID;
            p_order.CustomerId = customerID;
            _context.Orders.Add(p_order);
            _context.SaveChanges();
            return p_order;
        }

        public Orders GetOrders(int p_customerID, double price)
        {
            List <Orders> orders = _context.Orders.Select(ord=>ord).ToList();
            foreach(Orders ord in orders)
            {
                if (ord.CustomerId == p_customerID && ord.Price == price)
                {
                    return ord;
                }
            }
            Orders newOrder = new Orders();
            newOrder.Id = -5;
            return newOrder;
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Select(cust => cust).ToList();
        }

        public List<StoreFront> GetAllStoreFronts()
        {
            return _context.StoreFronts.Select(store => store).ToList();
        }

        public Customer GetCustomer(Customer p_customer)
        {
            List<Customer> customers = _context.Customers.Select(cust=> cust).ToList();
            foreach(Customer cust in customers)
            {
                if (p_customer.Name == cust.Name && p_customer.Password == cust.Password) {return cust;}
                else if (p_customer.Address == cust.Address && p_customer.Password == cust.Password) {return cust;}
                else if (p_customer.Email == cust.Email && p_customer.Password == cust.Password) {Console.WriteLine("Match Found");return cust;} 
                else if (p_customer.PhoneNumber == cust.PhoneNumber && p_customer.Password == cust.Password){return cust;} 
            }
            p_customer.Name = "Invalid Entry";
            return p_customer;

        }

        public List<LineItems> GetInventory(int p_id)
        {
            List<LineItems> totalInventory = _context.LineItems.Select(
                inv=> inv).ToList();
            List<LineItems> storeInventory = new List<LineItems>();
            foreach (LineItems inv in totalInventory )
            {
                if (inv.storeId == p_id){storeInventory.Add(inv);}
            }
            return storeInventory;
        }

        public List<Orders> GetOrders(int p_storeFront)
        {
            List<Orders> allOrders = _context.Orders.Select(
                Ord=> Ord).ToList();
            List<Orders> storeOrders = new List<Orders>();
            foreach (Orders order in allOrders)
            {
                if (order.StoreId == p_storeFront){storeOrders.Add(order);}
            }
            return storeOrders;
        }

        public List<Orders> GetOrders(Customer p_customer)
        {
            List<Orders> allOrders = _context.Orders.Select(
                Ord=> Ord).ToList();
            List<Orders> customerOrders = new List<Orders>();
            foreach(Orders order in allOrders)
            {
                if (order.CustomerId == p_customer.Id){customerOrders.Add(order);}
            }
            return customerOrders;
        }

        public List<Products> GetProducts(int storeId)
        {
            List<Products> totalProducts = _context.Products.Select(
                pro=>pro).ToList();
            List<Products> storeProducts = new List<Products>();
            foreach (Products pro in totalProducts)
            {
                if (pro.StoreId == storeId){storeProducts.Add(pro);}
            }
            return storeProducts;
        }
    }
}
