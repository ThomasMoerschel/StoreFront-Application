using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreAppModels;
namespace StoreAppUI
{
    public class SearchCustomerMenu : IMenu
    {
        public static Customer _newCustomer = new Customer();
        private ICustomerBL _customerBL;
        public SearchCustomerMenu(){}
        public SearchCustomerMenu(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void Menu()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("How would you like to search?");
            Console.WriteLine("==============================");
            Console.WriteLine("[4] Search by Name");
            Console.WriteLine("[3] Search by Phone Number");
            Console.WriteLine("[2] Search by Address");
            Console.WriteLine("[1] Search by Email");
            Console.WriteLine("==============================");
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
                    Console.WriteLine("Please Enter Customer Email:");
                    Console.WriteLine("-------------------------------------");

                    _newCustomer.Email = Console.ReadLine();
                    _newCustomer.Name =_customerBL.GetCustomer(_newCustomer).Name;

                    if (_newCustomer.Name == "Invalid Entry")
                    {
                        Console.WriteLine("========================");
                        Console.WriteLine("Customer Not Found!");
                        Console.WriteLine("Press ENTER to continue");
                        Console.WriteLine("========================");
                        Console.ReadLine();
                    }
                    else
                    {
                        _newCustomer.Id = _customerBL.GetCustomer(_newCustomer).Id;
                        _newCustomer.Address = _customerBL.GetCustomer(_newCustomer).Address;
                        _newCustomer.PhoneNumber = _customerBL.GetCustomer(_newCustomer).PhoneNumber;
                        Console.Clear();
                        Console.WriteLine("==============================");
                        Console.WriteLine("Customer Found!");
                        Console.WriteLine("==============================");
                        Console.WriteLine(_newCustomer);
                        Console.WriteLine("==============================");
                        Console.WriteLine("[0] Go Back");
                        Console.ReadLine();
                        _newCustomer.Name = "";
                        _newCustomer.Address = "";
                        _newCustomer.Email = "";
                        _newCustomer.PhoneNumber = "";
                    }
                    return MenuType.SearchCustomerMenu;
                    
                case "2":
                    Console.WriteLine("Please Enter Customer Address:");
                    Console.WriteLine("-------------------------------------");
                    _newCustomer.Address = Console.ReadLine();
                    _newCustomer.Name =_customerBL.GetCustomer(_newCustomer).Name;

                    if (_newCustomer.Name == "Invalid Entry")
                    {
                        Console.WriteLine("========================");
                        Console.WriteLine("Customer Not Found!");
                        Console.WriteLine("Press ENTER to continue");
                        Console.WriteLine("========================");
                        Console.ReadLine();
                    }
                    else
                    {
                        _newCustomer.Id = _customerBL.GetCustomer(_newCustomer).Id;
                        _newCustomer.Email = _customerBL.GetCustomer(_newCustomer).Email;
                        _newCustomer.PhoneNumber = _customerBL.GetCustomer(_newCustomer).PhoneNumber;
                        Console.Clear();
                        Console.WriteLine("==============================");
                        Console.WriteLine("Customer Found!");
                        Console.WriteLine("==============================");
                        Console.WriteLine(_newCustomer);
                        Console.WriteLine("==============================");
                        Console.WriteLine("Press ENTER to conitnue");
                        Console.ReadLine();
                        _newCustomer.Name = "";
                        _newCustomer.Address = "";
                        _newCustomer.Email = "";
                        _newCustomer.PhoneNumber = "";
                    }
                    return MenuType.SearchCustomerMenu;
                case "3":
                     Console.WriteLine("Please Enter Customer Phone Number:");
                     Console.WriteLine("-------------------------------------");
                    _newCustomer.PhoneNumber  = Console.ReadLine();
                    _newCustomer.Name =_customerBL.GetCustomer(_newCustomer).Name;

                    if (_newCustomer.Name == "Invalid Entry")
                    {
                        Console.WriteLine("========================");
                        Console.WriteLine("Customer Not Found!");
                        Console.WriteLine("Press ENTER to continue");
                        Console.WriteLine("========================");
                        Console.ReadLine();
                    }
                    else
                    {
                        _newCustomer.Id = _customerBL.GetCustomer(_newCustomer).Id;
                        _newCustomer.Address = _customerBL.GetCustomer(_newCustomer).Address;
                        _newCustomer.Email = _customerBL.GetCustomer(_newCustomer).Email;
                        _newCustomer.PhoneNumber = _customerBL.GetCustomer(_newCustomer).PhoneNumber;
                        Console.Clear();
                        Console.WriteLine("==============================");
                        Console.WriteLine("Customer Found!");
                        Console.WriteLine("==============================");
                        Console.WriteLine(_newCustomer);
                        Console.WriteLine("==============================");
                        Console.WriteLine("Press ENTER to conitnue");
                        Console.ReadLine();
                        _newCustomer.Name = "";
                        _newCustomer.Address = "";
                        _newCustomer.Email = "";
                        _newCustomer.PhoneNumber = "";
                    }
                    return MenuType.SearchCustomerMenu;
                case "4":
                    Console.WriteLine("Please Enter Customer Name:");
                    Console.WriteLine("-------------------------------------");
                    _newCustomer.Name  = Console.ReadLine();
                    _newCustomer.Name =_customerBL.GetCustomer(_newCustomer).Name;

                    if (_newCustomer.Name == "Invalid Entry")
                    {
                        Console.WriteLine("========================");
                        Console.WriteLine("Customer Not Found!");
                        Console.WriteLine("Press ENTER to continue");
                        Console.WriteLine("========================");
                        Console.ReadLine();
                    }
                    else
                    {
                        _newCustomer.Id = _customerBL.GetCustomer(_newCustomer).Id;
                        _newCustomer.Address = _customerBL.GetCustomer(_newCustomer).Address;
                        _newCustomer.Email = _customerBL.GetCustomer(_newCustomer).Email;
                        _newCustomer.PhoneNumber = _customerBL.GetCustomer(_newCustomer).PhoneNumber;
                        Console.Clear();
                        Console.WriteLine("==============================");
                        Console.WriteLine("Customer Found!");
                        Console.WriteLine("==============================");
                        Console.WriteLine(_newCustomer);
                        Console.WriteLine("==============================");
                        Console.WriteLine("Press ENTER to conitnue");
                        Console.ReadLine();
                        _newCustomer.Name = "";
                        _newCustomer.Address = "";
                        _newCustomer.Email = "";
                        _newCustomer.PhoneNumber = "";
                    }
                    return MenuType.SearchCustomerMenu;
                default:
                    Console.WriteLine("========================");
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press ENTER to Continue");
                    Console.WriteLine("========================");
                    Console.ReadLine();
                    return MenuType.SearchCustomerMenu;
            }
        }
    }
}