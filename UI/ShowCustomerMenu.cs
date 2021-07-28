using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI
{
    public class ShowCustomerMenu : IMenu
    {
        private ICustomerBL _customerBL;
        public ShowCustomerMenu(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void Menu()
        {
            Console.WriteLine("================================");
            Console.WriteLine("List of Customers:");
            Console.WriteLine("================================");
            List <Customer> customers = _customerBL.GetAllCustomers();
            Console.WriteLine("--------------------------------");
            foreach (Customer cust in customers)
            {
                Console.WriteLine(cust);
                Console.WriteLine("--------------------------------");
            }
            Console.WriteLine("================================");
            Console.WriteLine("[0] Go Back");
            
        }

        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.CustomerMenu;
                default:
                    Console.WriteLine("========================");
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press ENTER to Continue");
                    Console.WriteLine("========================");
                    Console.ReadLine();
                    return MenuType.CustomerMenu;
            }
        }
    }
}