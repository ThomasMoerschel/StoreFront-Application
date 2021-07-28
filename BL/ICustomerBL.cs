using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppBL
{
    public interface ICustomerBL
    {
         List <Customer> GetAllCustomers();
         Customer AddCustomer(Customer p_customer);
         Customer GetCustomer(Customer p_customer);
    }
}