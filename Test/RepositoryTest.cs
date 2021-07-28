using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreAppDL;
using StoreAppModels;
using Xunit;

namespace Test
{
    //constructors in unit test will always run before a test case
    public class RepositoryTest
    {
        private readonly DbContextOptions<StoreAppDBContext> _options;
        //in line memory database to test on
        public RepositoryTest()
        {
            _options = new DbContextOptionsBuilder<StoreAppDBContext>().UseSqlite("Filename = Test.db").Options;
            this.Seed();
        }
        [Fact]
        public void GetAllCustomersShouldGetAllCustomers()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                //arrange
                IRepository repo = new Repository(context);
                List<Customer> customers;
                //act
                customers = repo.GetAllCustomers();
                //assert
                Assert.NotNull(customers);
                Assert.Equal(2, customers.Count);
            }
        }
        [Fact]
        public void GetCustomerShouldGetSpecificCustomerByName()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                IRepository repo = new Repository(context);
                Customer tryToFindCust = new Customer()
                {
                    Name = "Test Name",
                    Password = "Password",
                };

                Customer found = repo.GetCustomer(tryToFindCust);

                Assert.NotNull(found);
                Assert.Equal(found.Name, tryToFindCust.Name);
            }
        }
        [Fact]
        public void GetCustomerShouldGetSpecificCustomerById()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                IRepository repo = new Repository(context);
                Customer tryToFindCust = new Customer()
                {
                    Id = 1,
                    Name = "Test Name",
                    Password = "Password",
                };

                Customer found = repo.GetCustomer(tryToFindCust);

                Assert.NotNull(found);
                Assert.Equal(found.Id, tryToFindCust.Id);
            }
        }
        [Fact]
        public void GetCustomerShouldGetSpecificCustomerByPhoneNumber()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                IRepository repo = new Repository(context);
                Customer tryToFindCust = new Customer()
                {
                    PhoneNumber = "Test Number",
                    Name = "Test Name",
                    Password = "Password",
                };

                Customer found = repo.GetCustomer(tryToFindCust);

                Assert.NotNull(found);
                Assert.Equal(found.PhoneNumber, tryToFindCust.PhoneNumber);
            }
        }
        [Fact]
        public void GetCustomerShouldGetSpecificCustomerByEmail()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                IRepository repo = new Repository(context);
                Customer tryToFindCust = new Customer()
                {
                    Email = "Test Email",
                    Name = "Test Name",
                    Password = "Password",
                };

                Customer found = repo.GetCustomer(tryToFindCust);

                Assert.NotNull(found);
                Assert.Equal(found.Email, tryToFindCust.Email);
            }
        }
        [Fact]
        public void GetStoreFrontsShouldGetAllStoreFronts()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                //arrange
                IRepository repo = new Repository(context);
                List<StoreFront> stores;
                //act
                stores = repo.GetAllStoreFronts();
                //assert
                Assert.NotNull(stores);
                Assert.Equal(2, stores.Count);
            }
        }
        [Fact]
        public void GetCustomerOrdersShouldGetCustomerOrders()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                //arrange
                IRepository repo = new Repository(context);
                Customer customerOrders = new Customer()
                {
                    Name = "Test Name",
                    Id = 1,
                };
                List<Orders> orders;
                //act
                orders = repo.GetOrders(customerOrders);
                //assert
                Assert.NotNull(orders);
                Assert.Equal(1, orders.Count);
            }
        }
        [Fact]
        public void GetStoreFrontOrdersShouldGetStoreFrontOrderHistory()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                //arrange
                IRepository repo = new Repository(context);
                List<Orders> orders;
                //act
                orders = repo.GetOrders(1);
                //assert
                Assert.NotNull(orders);
                Assert.Equal(1, orders.Count);
            }
        }
        [Fact]
        public void GetStoreFrontInventoryShouldReturnStoreFrontInventory()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                //arrange
                IRepository repo = new Repository(context);
                List<LineItems> items;
                //act
                items = repo.GetInventory(1);
                //assert
                Assert.NotNull(items);
                Assert.Equal(2, items.Count);
            }
        }
        [Fact]
        public void GetEmptyStoreInventoryShouldNotReturnAnInventory()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                //arrange
                IRepository repo = new Repository(context);
                List<LineItems> items;
                //act
                items = repo.GetInventory(2);
                //assert
                Assert.Equal(0, items.Count);
            }
        }
        [Fact]
        public void GetProductsByStoreIDShouldGetAllProductsForStoreFront()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                //arrange
                IRepository repo = new Repository(context);
                List<Products> pro;
                //act
                pro = repo.GetProducts(1);
                //assert
                Assert.Equal(2, pro.Count);
            }
        }
        [Fact]
        public void GetProductsByStoreIDWhenEmptyShouldNotReturnAnyProducts()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                //arrange
                IRepository repo = new Repository(context);
                List<Products> pro;
                //act
                pro = repo.GetProducts(2);
                //assert
                Assert.Equal(0, pro.Count);
            }
        }
        [Fact]
        public void GetOrderByCustomerIDAndOrderPriceShouldReturnCustomerOrder()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                //arrange
                IRepository repo = new Repository(context);
                Orders custOrder = new Orders();
                //act
                custOrder = repo.GetOrders(1, 21.99);
                //assert
                Assert.Equal(custOrder.Id, 1);
            }
        }
        [Fact]
        public void AddOrderShouldAddAnotherOrder()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                //arrange
                IRepository repo = new Repository(context);
                Orders custOrder = new Orders()
                {
                    Id = 3,
                    StoreId = 1,
                    CustomerId = 1,
                    Price = 25.99,
                };
                Orders compareOrder = new Orders();
                repo.AddOrder(1, 1, custOrder);
                //act
                compareOrder = repo.GetOrders(1, 25.99);
                //assert
                Assert.NotNull(compareOrder);
                Assert.Equal(compareOrder.Id, custOrder.Id);
            }
        }
        [Fact]
        public void AddInventoryShouldAddInventory()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                //arrange
                IRepository repo = new Repository(context);
                LineItems invItem = new LineItems()
                {
                    Id = 1,
                    storeId = 1,
                    Product = "Test Product",
                    Quantity = 21,
                    ProductsId = 1,
                };
                repo.AddInventory(invItem, 10);
                //act
                LineItems compareInv = new LineItems();
                var list = repo.GetInventory(1);
                foreach (LineItems item in list)
                {
                    if (item.Id == invItem.Id)
                    {
                        compareInv = item;
                    }
                }
                //assert
                Assert.Equal((invItem.Quantity + 10), compareInv.Quantity);
            }
        }
        private void Seed()
        {
            using (var context = new StoreAppDBContext(_options))
            {
                //makes sure the in-memory database is deleted everytime before another test case runs
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.AddRange(
                    new Customer 
                    {
                        Id = 1,
                        Name = "Test Name",
                        Address = "Test Address",
                        Email = "Test Email",
                        PhoneNumber = "Test Number",
                        Password = "Password",
                        Manager = 0,
                       
                    },
                    new Customer 
                    {
                        Id = 2,
                        Name = "Test2 Name",
                        Address = "Test2 Address",
                        Email = "Test2 Email",
                        PhoneNumber = "Test2 Number",
                        Password = "Password2",
                        Manager = 1,
                    }
                );
                context.StoreFronts.AddRange(
                    new StoreFront
                    {
                        Id = 1,
                        Name = "Test1 Name",
                        Address = "Test1 Address"
                    },
                    new StoreFront
                    {
                        Id = 2,
                        Name = "Test2 Name",
                        Address = "Test2 Address",
                    }
                );
                context.Orders.AddRange(
                    new Orders
                    {
                        Id = 1,
                        StoreId = 1,
                        CustomerId = 1,
                        Price = 21.99,
                    },
                    new Orders
                    {
                        Id = 2,
                        StoreId = 2,
                        CustomerId = 2,
                        Price = 22.99,
                    }
                );
                context.LineItems.AddRange(
                    new LineItems
                    {
                        Id = 1,
                        storeId = 1,
                        Product = "Test Product",
                        Quantity = 21,
                        ProductsId = 1,
                    },
                    new LineItems
                    {
                        Id = 2,
                        storeId = 1,
                        Product = "Test2 Product",
                        Quantity = 22,
                        ProductsId = 2,
                    }
                );
                context.Products.AddRange(
                    new Products
                    {
                        Id = 1,
                        StoreId = 1,
                        Name = "Test product",
                        Price = 21.99,
                        Category = "Test Cat",
                    },
                    new Products
                    {
                        Id = 2,
                        StoreId = 1,
                        Name = "Test2 product",
                        Price = 22.99,
                        Category = "test2 Cat",
                    }
                );
                context.SaveChanges();
            }
        }

    }
}
