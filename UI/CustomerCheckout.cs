using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI
{
    public class CustomerCheckout : IMenu
    {
        private IInventoryBL _InventoryBL;
        private IOrderBL _OrderBL;
        public CustomerCheckout(){}
        public CustomerCheckout(IInventoryBL p_InventoryBL, IOrderBL p_OrderBL)
        {
            _InventoryBL = p_InventoryBL;
            _OrderBL = p_OrderBL;
        }
        public static StoreFront storeCheckout = new StoreFront();
        public static Customer customerCheckout = new Customer();
        public static List<LineItems> checkoutCart = new List<LineItems>();
        public static double price;
        public void checkoutInformation(StoreFront p_storeFront, Customer p_customer, List<LineItems> p_cart, double p_price)
        {
            storeCheckout = p_storeFront;
            customerCheckout = p_customer;
            checkoutCart = p_cart;
            price = p_price;
        }
        public void Menu()
        {
            Console.WriteLine("===============================================");
            Console.WriteLine(storeCheckout.Name + " Checkout!");
            Console.WriteLine("===============================================");
            Console.WriteLine("Items in Cart:");
            Console.WriteLine("---------------------------");
            foreach (LineItems item in checkoutCart)
            {
                Console.WriteLine(item);
                Console.WriteLine("---------------------------");
            }
            double totalPrice = Math.Round(price, 2, MidpointRounding.AwayFromZero);
            Console.WriteLine("Total Price: $" + totalPrice);
            Console.WriteLine("===============================================");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("===============================================");
            Console.WriteLine("[1] Complete Purchase");
            Console.WriteLine("[0] Cancel Order and Return to Main Menu");
        }

        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    foreach (LineItems item in checkoutCart)
                    {
                        _InventoryBL.AddInventory(item, item.Quantity);
                    }
                    checkoutCart.Clear();
                    return MenuType.MainMenu;
                case "1":
                    PurchaseConfirmation newConfirmation = new PurchaseConfirmation();
                    Orders newOrder = new Orders();
                    newOrder.Price = price;
                    _OrderBL.AddOrder(storeCheckout, customerCheckout, newOrder);
                    newConfirmation.customerInformation(customerCheckout, checkoutCart, price);
                    return MenuType.PurchaseConfirmation;
                default:
                    return MenuType.CustomerCheckout;
            }
        }
    }
}