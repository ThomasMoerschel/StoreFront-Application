using System;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI
{
    public class AddCustomerMenu : IMenu
    {   
        public static Customer _newCustomer = new Customer();
        private ICustomerBL _customerBL;
        public AddCustomerMenu(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void Menu()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("[5] Name: " + _newCustomer.Name);
            Console.WriteLine("[4] Address: "+ _newCustomer.Address);
            Console.WriteLine("[3] Phone Number: "+ _newCustomer.PhoneNumber);
            Console.WriteLine("[2] Email: "+_newCustomer.Email);
            Console.WriteLine("[1] Add Customer");
            Console.WriteLine("=======================================");
            Console.WriteLine("[0] Go Back");
        }
        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return MenuType.CustomerMenu;
                case "1":
                    _customerBL.AddCustomer(_newCustomer);
                    _newCustomer = new Customer();
                    return MenuType.CustomerMenu;
                case "2":
                    Console.WriteLine("Input Customer Email:");
                    Console.WriteLine("----------------------------");
                    _newCustomer.Email = Console.ReadLine();
                    return MenuType.AddCustomerMenu;
                case "3":
                    Console.WriteLine("Input Customer Phone Number:");
                    Console.WriteLine("----------------------------");
                    _newCustomer.PhoneNumber = Console.ReadLine();
                    return MenuType.AddCustomerMenu;
                case "4":
                    Console.WriteLine("Input Customer Address:");
                    Console.WriteLine("----------------------------");
                    _newCustomer.Address = Console.ReadLine();
                    return MenuType.AddCustomerMenu;
                case "5":
                    Console.WriteLine("Input Customer Name:");
                    Console.WriteLine("----------------------------");
                    _newCustomer.Name = Console.ReadLine();
                    return MenuType.AddCustomerMenu;
                default:
                    Console.WriteLine("========================");
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press ENTER to Continue");
                    Console.WriteLine("========================");
                    Console.ReadLine();
                    return MenuType.AddCustomerMenu;
            }
        }
    }
}