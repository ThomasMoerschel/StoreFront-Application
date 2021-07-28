
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

using StoreAppBL;
using StoreAppDL;

namespace StoreAppUI
{
    public class MenuFactory : IFactory
    {
        public IMenu GetMenu(MenuType p_menu)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = configuration.GetConnectionString("DatabaseReference");
            DbContextOptions<FirstDatabaseContext> options = new DbContextOptionsBuilder<FirstDatabaseContext>()
                .UseSqlServer(connectionString)
                .Options;
            switch (p_menu)
            {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.CustomerMenu:
                    return new CustomerMenu();
                case MenuType.ShowCustomerMenu:
                    return new ShowCustomerMenu(new CustomerBL(new Repository(new FirstDatabaseContext(options))));
                case MenuType.AddCustomerMenu:
                    return new AddCustomerMenu(new CustomerBL(new Repository(new FirstDatabaseContext(options))));
                case MenuType.SearchCustomerMenu:
                    return new SearchCustomerMenu(new CustomerBL(new Repository(new FirstDatabaseContext(options))));
                case MenuType.StoreFrontMenu:
                    return new StoreFrontMenu();
                case MenuType.StoreFrontInventoryMenu:
                    return new StoreFrontInventoryMenu();
                case MenuType.ManagementFindStoreFrontMenu:
                    return new ManagementFindStoreFrontMenu(new StoreFrontBL(new Repository(new FirstDatabaseContext(options))));
                case MenuType.ViewInventory:
                    return new ViewInventory(new InventoryBL(new Repository(new FirstDatabaseContext(options))));
                case MenuType.AddInventory:
                    return new AddInventory(new InventoryBL(new Repository(new FirstDatabaseContext(options))));
                case MenuType.StoreOrderHistory:
                    return new StoreOrderHistory(new OrderBL(new Repository(new FirstDatabaseContext(options))));
                case MenuType.CustomerOrderHistory:
                    return new CustomerOrderHistory(new OrderBL(new Repository(new FirstDatabaseContext(options))));
                case MenuType.CustomerFindStoreFrontMenu:
                    return new CustomerFindStoreFrontMenu(new StoreFrontBL(new Repository(new FirstDatabaseContext(options))));
                case MenuType.MakeAnOrder:
                    return new MakeAnOrder(new InventoryBL(new Repository(new FirstDatabaseContext(options))), new ProductsBL(new Repository(new FirstDatabaseContext(options))));
                case MenuType.CustomerValidation:
                    return new CustomerValidation(new CustomerBL(new Repository(new FirstDatabaseContext(options))));
                case MenuType.CustomerCheckout:
                    return new CustomerCheckout(new InventoryBL(new Repository(new FirstDatabaseContext(options))), new OrderBL(new Repository(new FirstDatabaseContext(options))));
                case MenuType.PurchaseConfirmation:
                    return new PurchaseConfirmation();
                case MenuType.SearchCustomerOrderHistory:
                    return new SearchCustomerOrderHistory(new CustomerBL(new Repository(new FirstDatabaseContext(options))));
                default:
                    return null;
            }
        }
    }
}