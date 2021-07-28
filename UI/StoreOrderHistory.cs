using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI
{
    public class StoreOrderHistory : IMenu
    {
        private IOrderBL _OrderBL;
        public StoreOrderHistory(){}
        public StoreOrderHistory(IOrderBL p_OrderBL){
            _OrderBL = p_OrderBL;
        }
        public static StoreFront store = new StoreFront();
        public void storeLocation(StoreFront p_storeFront)
        {
            store = p_storeFront;
        }
        public void Menu()
        {
            double totalRevenue = 0.00;
            List <Orders> storeOrders = _OrderBL.GetOrders(store);
            Console.WriteLine("==================================================");
            Console.WriteLine(store.Name + " Order History");
            Console.WriteLine("==================================================");
            Console.WriteLine("--------------------------------------------------");
            foreach (Orders order in storeOrders)
            {
                totalRevenue += order.Price;
                Console.WriteLine(order);
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine("                         Total Revenue: $" + Math.Round(totalRevenue, 2, MidpointRounding.AwayFromZero));
            Console.WriteLine("==================================================");
            Console.WriteLine("[0] Go Back");
        }
        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return MenuType.StoreFrontMenu;
                default:
                    Console.WriteLine("========================");
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press ENTER to Continue");
                    Console.WriteLine("========================");
                    Console.ReadLine();
                    return MenuType.StoreOrderHistory;
            }
        }
    }
}