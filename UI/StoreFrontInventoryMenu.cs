using System;
using StoreAppModels;

namespace StoreAppUI
{
    public class StoreFrontInventoryMenu : IMenu
    {
        public static StoreFront store = new StoreFront();
        public void storeLocation(StoreFront p_storeFront)
        {
            store = p_storeFront;
        }
        public void Menu()
        {
            Console.WriteLine("=========================================================================");
            Console.WriteLine("Welcome to " + store.Name + " Inventory Managment Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("=========================================================================");
            Console.WriteLine("[2] View Inventory");
            Console.WriteLine("[1] Replenish Inventory");
            Console.WriteLine("=========================================================================");
            Console.WriteLine("[0] Go Back");
        }
        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();
            ViewInventory viewLocation = new ViewInventory();
            AddInventory addLocation = new AddInventory();
            switch (userInput)
            {
                case "0":
                    return MenuType.StoreFrontMenu;
                case "1":
                    addLocation.storeLocation(store);
                    return MenuType.AddInventory;
                case "2":
                    viewLocation.storeLocation(store);
                    return MenuType.ViewInventory;
                default:
                    Console.WriteLine("========================");
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press ENTER to Continue");
                    Console.WriteLine("========================");
                    Console.ReadLine();
                    return MenuType.StoreFrontInventoryMenu;
            }
        }
    }
}