using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppUI
{
    public class PurchaseConfirmation : IMenu
    {
        public static Customer customerPurchase = new Customer();
        public static List<LineItems> cart = new List<LineItems>();
        public static double price;
        public void customerInformation (Customer p_cusotmer, List<LineItems> p_cart, double p_price)
        {
            customerPurchase = p_cusotmer;
            cart = p_cart;
            price = p_price;
        }
        public void Menu()
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("Thank you " + customerPurchase.Name + " for your purchase!");
            Console.WriteLine();
            Console.WriteLine("A Confirmation Email has been sent to: " + customerPurchase.Email);
            Console.WriteLine();
            Console.WriteLine("Your order will be delivered to:\n" + customerPurchase.Address);
            Console.WriteLine("=======================================================================");
            Console.WriteLine("Order Details:");
            Console.WriteLine("---------------------------");
            foreach (LineItems item in cart)
            {
                Console.WriteLine(item);
                Console.WriteLine("---------------------------");
            }
            Console.WriteLine("=======================================================================");
            Console.WriteLine("Order Price: " + Math.Round(price, 2, MidpointRounding.AwayFromZero));
            Console.WriteLine("=======================================================================");
            Console.WriteLine("[0] Return to Main Menu");
        }
        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    cart.Clear();
                    return MenuType.MainMenu;
                default:
                    return MenuType.PurchaseConfirmation;
            }
        }
    }
}