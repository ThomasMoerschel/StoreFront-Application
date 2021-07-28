using System.Collections.Generic;
using System;
using StoreAppDL;
using StoreAppModels;

namespace StoreAppBL
{
    public class CustomerBL : ICustomerBL
    {
        private IRepository _repo;
        public CustomerBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public Customer AddCustomer(Customer p_customer)
        {
            return _repo.AddCustomer(p_customer);
        }
        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }
        public Customer GetCustomer(Customer p_customer)
        {
            return _repo.GetCustomer(p_customer);
        }
    }
}
