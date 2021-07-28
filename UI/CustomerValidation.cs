using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI
{
    public class CustomerValidation : IMenu
    {
        private ICustomerBL _customerBL;
        public CustomerValidation(){}
        public static StoreFront store = new StoreFront();
        public void storeLocation(StoreFront p_storeFront){
            store = p_storeFront;
        }
        public CustomerValidation(ICustomerBL p_customerBL) 
        {
            _customerBL = p_customerBL;
        }
        public void Menu()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("Welcome to " + store.Name);
            Console.WriteLine("Customer Sign-up or Login");
            Console.WriteLine("==================================================");
            Console.WriteLine("[2] Customer Sign Up");
            Console.WriteLine("[1] Customer Login");
            Console.WriteLine("==================================================");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserInput()
        {
            MakeAnOrder newOrder = new MakeAnOrder();
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return MenuType.CustomerFindStoreFrontMenu;
                case "1":
                    List <Customer> customers = _customerBL.GetAllCustomers();
                    Console.WriteLine("Please Input your full name:");
                    Console.WriteLine("--------------------------------");
                    string tempName = Console.ReadLine();
                    foreach (Customer cust in customers)
                    {
                        if (tempName == cust.Name)
                        {
                            newOrder.storeLocation(store);
                            newOrder.customerInformation(cust);
                            return MenuType.MakeAnOrder; 
                        }
                    }
                    Console.WriteLine("==========================================");
                    Console.WriteLine("Name not found, try adding a new customer");
                    Console.WriteLine("Press ENTER to Continue");
                    Console.WriteLine("==========================================");
                    Console.ReadLine();
                        return MenuType.CustomerValidation;
                case "2":
                    Customer newCustomer = new Customer();
                    Console.Clear();
                    Console.WriteLine("Please Input your Full Name");
                    Console.WriteLine("--------------------------------");
                    string customerName = Console.ReadLine();
                    newCustomer.Name = customerName;
                    Console.WriteLine("Please Input your Phone Number");
                    Console.WriteLine("--------------------------------");
                    string customerPhoneNumber = Console.ReadLine();
                    newCustomer.PhoneNumber = customerPhoneNumber;
                    Console.WriteLine("Please input your Email");
                    Console.WriteLine("--------------------------------");
                    string customerEmail = Console.ReadLine();
                    newCustomer.Email = customerEmail;
                    Console.WriteLine("Please Input your Address");
                    Console.WriteLine("--------------------------------");
                    string customerAddress = Console.ReadLine();
                    newCustomer.Address = customerAddress;
                    _customerBL.AddCustomer(newCustomer);
                    newOrder.storeLocation(store);
                        return MenuType.CustomerValidation;
                default:
                    Console.WriteLine("========================");
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press ENTER to Continue");
                    Console.WriteLine("========================");
                    Console.ReadLine();
                    return MenuType.CustomerValidation;

            }
        }
    }
}