using System;
using System.Collections.Generic;
using System.Linq;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI
{
    public class MakeAnOrder : IMenu
    {
        private IInventoryBL _InventoryBL;
        private IProductsBL _ProductsBL;
        public MakeAnOrder(){}
        public MakeAnOrder(IInventoryBL p_InventoryBL, IProductsBL p_IProductsBL)
        {
            _InventoryBL = p_InventoryBL;
            _ProductsBL = p_IProductsBL;
        }
        public static Customer shoppingCustomer = new Customer();
        public static StoreFront shoppingStoreFront = new StoreFront();
        public static List<LineItems> cart = new List<LineItems>();
        public void storeLocation(StoreFront p_storeFront)
        {
            shoppingStoreFront = p_storeFront;
        }
        public void customerInformation(Customer p_customer)
        {
            shoppingCustomer = p_customer;
        }
        
        public void Menu()
        {
            Console.WriteLine("===================================================================");
            Console.WriteLine("Welcome " + shoppingCustomer.Name + " to " + shoppingStoreFront.Name);
            Console.WriteLine(shoppingStoreFront.Name + " Summer Catalog:");
            Console.WriteLine("===================================================================");
            List<LineItems> lineItems = _InventoryBL.GetInventory(shoppingStoreFront);
            List<Products> products = _ProductsBL.GetProducts(shoppingStoreFront);
            Console.WriteLine("-------------------");
            foreach(Products prod in products)
            {
                 if (prod.StoreId == shoppingStoreFront.Id)
                {
                    Console.WriteLine(prod);
                    double productPrice = Math.Round(prod.Price, 2, MidpointRounding.AwayFromZero);
                    foreach(LineItems item in lineItems)
                    {
                        if (item.Product == prod.Name)
                        {
                            Console.WriteLine ("Quantity: " + item.Quantity);
                            Console.WriteLine("Price: " + productPrice);
                            Console.WriteLine("-------------------");
                        }
                    }
                }
            }
        }
        public MenuType UserInput()
        {
            List<LineItems> lineItems = _InventoryBL.GetInventory(shoppingStoreFront);
            List<Products> products = _ProductsBL.GetProducts(shoppingStoreFront);
            Console.WriteLine("===================================================================");
            Console.WriteLine("Which Item would you like to purchase?\n(Choose by Product ID or Product Name)");
            Console.WriteLine("===================================================================");
            double price = 0.00;
            string userInput = Console.ReadLine();
            string invQuantity;
            int count = 0;
            foreach(LineItems item in lineItems)
            {
                if (userInput == item.Id.ToString() || item.Product.ToLower() == userInput.ToLower())
                {
                    count++;
                    Console.WriteLine("=============================================");
                    Console.WriteLine("How many would you like to add to your cart?");
                    Console.WriteLine("=============================================");
                    string quantity = Console.ReadLine();
                    if (quantity.Contains("-"))
                    {
                        Console.WriteLine("===================================================================");
                        Console.WriteLine("Cannot add a negative quantity... Press ENTER to continue.");
                        Console.WriteLine("===================================================================");
                        Console.ReadLine();
                        return MenuType.MakeAnOrder;
                    }
                    if (Int32.Parse(quantity) > item.Quantity)
                    {
                        Console.WriteLine("===================================================================");
                        Console.WriteLine("Not enough avaliable inventory to complete purchase...\nPress ENTER to continue.");
                        Console.WriteLine("===================================================================");
                        Console.ReadLine();
                        return MenuType.MakeAnOrder;
                    }
                    invQuantity = "-" + quantity;
                    item.Quantity = Int32.Parse(quantity);
                    _InventoryBL.AddInventory(item, Int32.Parse(invQuantity));
                    if (cart.Count > 0)
                    {
                        foreach (LineItems product in cart.ToList())
                        {
                            if (product.Id.ToString() == userInput || product.Product.ToLower() == userInput.ToLower())
                            {
                                product.Quantity += Int32.Parse(quantity);
                            }
                            else
                            {
                                cart.Add(item);
                            }
                        }
                    }
                    else
                    {
                        cart.Add(item);   
                    }
                } 
            }
            if (count == 0)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine("Improper Input!");
                Console.WriteLine("Press ENTER to continue...");
                Console.WriteLine("===================================================================");
                Console.ReadLine();
                return MenuType.MakeAnOrder;
            }
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("Would you like to make another purchase?");
            Console.WriteLine("[2] Make another Purchase\n[1] Continue to Checkout\n[0] Cancel Order");
            Console.WriteLine("========================================");
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    foreach (LineItems item in cart)
                    {
                        _InventoryBL.AddInventory(item, item.Quantity);
                    }
                    cart.Clear();
                    return MenuType.MainMenu;
                case "1":
                    CustomerCheckout checkout = new CustomerCheckout();
                    foreach (LineItems item in cart)
                    {
                        foreach (Products product in products)
                        {
                            if (item.Id == product.ProductId)
                            {
                                price += (product.Price * item.Quantity);
                            }
                        }
                    }
                    checkout.checkoutInformation(shoppingStoreFront, shoppingCustomer, cart, price);
                    return MenuType.CustomerCheckout;
                case "2":

                    return MenuType.MakeAnOrder;
            }
            return MenuType.MakeAnOrder;
        }
    }
}