using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI
{
    public class ViewInventory : IMenu
    {
        private IInventoryBL _InventoryBL;
        public static StoreFront store = new StoreFront();
        public ViewInventory(){}
        public ViewInventory(IInventoryBL p_InventoryBL)
        {
            _InventoryBL = p_InventoryBL;
        }
        public void storeLocation(StoreFront p_storeFront)
        {
            store = p_storeFront;
        }
        public void Menu()
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine(store.Name + " Inventory:");
            Console.WriteLine("=====================================================");
            List<LineItems> lineItems = _InventoryBL.GetInventory(store);
            Console.WriteLine("------------------------");
            foreach (LineItems item in lineItems)
            {
                Console.WriteLine(item);
                Console.WriteLine("------------------------");
            }
            Console.WriteLine("=====================================================");
            Console.WriteLine("[0] Go Back");
        }
        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.StoreFrontInventoryMenu;
                default:
                    Console.WriteLine("========================");
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press ENTER to Continue");
                    Console.WriteLine("========================");
                    Console.ReadLine();
                    return MenuType.ViewInventory;
            }
        }
    }
}