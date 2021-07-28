using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppDL

{
    public interface IRepository
    {
         List<Customer> GetAllCustomers();

         Customer GetCustomer(Customer p_customer);

         Customer AddCustomer(Customer p_customer);
         List<StoreFront> GetAllStoreFronts();
         LineItems AddInventory(LineItems p_lineItems, int quantity);
         List<LineItems> GetInventory(int p_id);
         List<Products> GetProducts(int storeID);
         List<Orders> GetOrders(int p_storeFront);
         List<Orders> GetOrders(Customer p_customer);
         Orders AddOrder(int storeID, int customerID, Orders p_order);
         Orders GetOrders(int p_customerID, double price);
    }
}