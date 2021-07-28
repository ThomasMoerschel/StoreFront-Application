using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace StoreAppUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu custMenu = new MainMenu();
            bool repeat = true;
            MenuType currentMenu = MenuType.MainMenu;
            IFactory menuFactory = new MenuFactory();
            while (repeat)
            {
                 try
                {
                    Console.Clear();
                }
                catch(SystemException)
                {
                    Console.WriteLine ("Console.Clear exception caught!");
                }
                custMenu.Menu();
                currentMenu = custMenu.UserInput();
                switch (currentMenu)
                {
                    case MenuType.MainMenu:
                        custMenu = menuFactory.GetMenu(MenuType.MainMenu);
                        break;
                    case MenuType.CustomerMenu:
                        custMenu = menuFactory.GetMenu(MenuType.CustomerMenu);
                        break;
                    case MenuType.ShowCustomerMenu:
                        custMenu = menuFactory.GetMenu(MenuType.ShowCustomerMenu);
                        break;
                    case MenuType.AddCustomerMenu:
                        custMenu = menuFactory.GetMenu(MenuType.AddCustomerMenu);
                        break;
                    case MenuType.SearchCustomerMenu:
                        custMenu = menuFactory.GetMenu(MenuType.SearchCustomerMenu);
                        break;
                    case MenuType.StoreFrontMenu:
                        custMenu = menuFactory.GetMenu(MenuType.StoreFrontMenu);
                        break;
                    case MenuType.ManagementFindStoreFrontMenu:
                        custMenu = menuFactory.GetMenu(MenuType.ManagementFindStoreFrontMenu);
                        break;
                    case MenuType.StoreFrontInventoryMenu:
                        custMenu = menuFactory.GetMenu(MenuType.StoreFrontInventoryMenu);
                        break;
                    case MenuType.StoreOrderHistory:
                        custMenu = menuFactory.GetMenu(MenuType.StoreOrderHistory);
                        break;
                    case MenuType.AddInventory:
                        custMenu = menuFactory.GetMenu(MenuType.AddInventory);
                        break;
                    case MenuType.ViewInventory:
                        custMenu = menuFactory.GetMenu(MenuType.ViewInventory);
                        break;
                    case MenuType.CustomerOrderHistory:
                        custMenu = menuFactory.GetMenu(MenuType.CustomerOrderHistory);
                        break;
                    case MenuType.CustomerFindStoreFrontMenu:
                        custMenu = menuFactory.GetMenu(MenuType.CustomerFindStoreFrontMenu);
                        break;
                    case MenuType.MakeAnOrder:
                        custMenu = menuFactory.GetMenu(MenuType.MakeAnOrder);
                        break;
                    case MenuType.CustomerValidation:
                        custMenu = menuFactory.GetMenu(MenuType.CustomerValidation);
                        break;
                    case MenuType.CustomerCheckout:
                        custMenu = menuFactory.GetMenu(MenuType.CustomerCheckout);
                        break;
                    case MenuType.PurchaseConfirmation:
                        custMenu = menuFactory.GetMenu(MenuType.PurchaseConfirmation);
                        break;
                    case MenuType.SearchCustomerOrderHistory:
                        custMenu = menuFactory.GetMenu(MenuType.SearchCustomerOrderHistory);
                        break;
                    case MenuType.Exit:
                        repeat = false;
                        Console.Clear();
                        Console.WriteLine("===========================================");
                        Console.WriteLine("Thank you for using the store application!");
                        Console.WriteLine("Goodbye!");
                        Console.WriteLine("===========================================");
                        break;
                    default:
                        Console.WriteLine("Cannot process Input... Please Try again.");
                        break;
                }
            }
        
        }
    }

}    