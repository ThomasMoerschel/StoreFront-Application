using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI
{
    public class ManagementFindStoreFrontMenu : IMenu
    {
        private IStoreFrontBL _storeFrontBL;
        public ManagementFindStoreFrontMenu(IStoreFrontBL p_storeFrontBL){
            _storeFrontBL = p_storeFrontBL;
        }
        public void Menu()
        {
           List<StoreFront> storeFronts = _storeFrontBL.GetAllStoreFronts();
            Console.WriteLine("=========================================================");
            Console.WriteLine("Please choose the store location");
            Console.WriteLine("Choose from the following or type the city of your shop!");
            Console.WriteLine("=========================================================");
            int count = 1;
            foreach (StoreFront store in storeFronts)
            {
                Console.WriteLine("[" + count + "] " + store.Address);
                count++;
            }
            Console.WriteLine("=========================================================");
            Console.WriteLine("[0] Go Back");
        }
        public MenuType UserInput()
        {
            StoreFrontMenu location = new StoreFrontMenu();
            List<StoreFront> storeFronts = _storeFrontBL.GetAllStoreFronts();
            string userInput = Console.ReadLine();
            switch (userInput.ToLower())
            {
                case "0":
                    return MenuType.MainMenu;
                case "atlanta" or "atlanta's" or "atlantas" or "1" or "atlanta, georgia" or "atlanta georgia":
                    location.storeLocation(storeFronts[0]);
                    return MenuType.StoreFrontMenu;
                case "gainesville" or "gainesville's" or "gainesvilles" or "2" or "gainesville florida" or "gainesville, florida":
                    location.storeLocation(storeFronts[1]);
                    return MenuType.StoreFrontMenu;
                case "fort myers" or "fort myers'" or "fortmyers" or "fortmyers'" or "3" or "fortmyers florida" or "fort myers florida" or "fort myers, florida" or "fortmyers, florida": 
                    location.storeLocation(storeFronts[2]);
                    return MenuType.StoreFrontMenu;
                default:
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("We could not find a store location based on your input!");
                    Console.WriteLine("You can select a store by Store ID or its location");
                    Console.WriteLine("Press ENTER to continue");
                    Console.WriteLine("=======================================================");
                    Console.ReadLine();
                    return MenuType.ManagementFindStoreFrontMenu;
            }
        }
    }
}