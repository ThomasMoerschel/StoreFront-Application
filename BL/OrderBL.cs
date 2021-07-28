using System;
using System.Collections.Generic;
using StoreAppDL;
using StoreAppModels;

namespace StoreAppBL
{
    public class OrderBL : IOrderBL
    {
        private IRepository _repo;
        public OrderBL(IRepository p_repo){
            _repo = p_repo;
        }
        public Orders AddOrder(int storeID, int customerID, Orders p_order)
        {
            return _repo.AddOrder(storeID, customerID, p_order);
        }
        public List<Orders> GetOrders(int p_storeFront)
        {
            return _repo.GetOrders(p_storeFront);
        }
        public List<Orders> GetOrders(Customer p_customer)
        {
            return _repo.GetOrders(p_customer);
        }

        public Orders GetOrders(int p_customerID, double price)
        {
            return _repo.GetOrders(p_customerID, price);
        }
    }
}