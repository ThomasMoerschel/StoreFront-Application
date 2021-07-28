using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI
{
    public class AddInventory : IMenu
    {
        private IInventoryBL _InventoryBL;
        public static StoreFront store = new StoreFront();
        public AddInventory(){}
        public AddInventory(IInventoryBL p_InventoryBL)
        {
            _InventoryBL = p_InventoryBL;
        }
        public void storeLocation(StoreFront p_storeFront)
        {
            store = p_storeFront;
        }
        public void Menu()
        {
            List<LineItems> lineItems = _InventoryBL.GetInventory(store);
            Console.WriteLine("======================================================");
            Console.WriteLine(store.Name + " Inventory Manager");
            Console.WriteLine("======================================================");
            Console.WriteLine("------------------------");
            foreach (LineItems item in lineItems)
            {
                Console.WriteLine(item);
                Console.WriteLine("------------------------");
            }
            Console.WriteLine("=====================================================");
            Console.WriteLine("Which Inventory Item would you like to restock?");
            Console.WriteLine("(Search by Product Name or Inventory ID)");
            Console.WriteLine("=====================================================");
            Console.WriteLine("[0] Go Back");
        }
        public MenuType UserInput()
        {
            List<LineItems> lineItems = _InventoryBL.GetInventory(store);
            string userInput = Console.ReadLine();
            foreach (LineItems item in lineItems)
            {
                if (userInput == item.Id.ToString() || item.Product == userInput)
                {   
                    Console.WriteLine("=====================================================");
                    Console.WriteLine("How many would you like to add?");
                    Console.WriteLine("=====================================================");
                    string quantity = Console.ReadLine();
                    if (quantity.Contains('-'))
                    {
                        Console.WriteLine("=========================================");
                        Console.WriteLine("Error! Cannot Input Negative Inventory!");
                        Console.WriteLine("=========================================");
                        Console.ReadLine();
                        return MenuType.AddInventory;
                    }
                    else
                    {
                        _InventoryBL.AddInventory(item, Int16.Parse(quantity));
                        return MenuType.AddInventory;
                    }
                }                
            }
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
                    return MenuType.AddInventory;
            }  
        }
    }
}