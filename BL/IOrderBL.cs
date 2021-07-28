using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppBL
{
    public interface IOrderBL
    {
         Orders GetOrders(int p_customerID, double price);
         List<Orders> GetOrders(int p_storeFront);
         List<Orders> GetOrders(Customer p_customer);
         Orders AddOrder(int storeID, int customerID, Orders order);
    }
}