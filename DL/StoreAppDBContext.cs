using Microsoft.EntityFrameworkCore;
using StoreAppModels;

namespace StoreAppDL
{
    public class StoreAppDBContext : DbContext
    {
        public DbSet <Customer> Customers { get; set; }
        public DbSet <LineItems> LineItems { get; set; }
        public DbSet <Orders> Orders { get; set; } 
        public DbSet <Products> Products { get; set; }
        public DbSet <StoreFront> StoreFronts {get; set;}
        public StoreAppDBContext() : base()
        { }
        public StoreAppDBContext(DbContextOptions options) : base(options)
        { }
        //protected override void OnConfiguring(DbContextOptionsBuilder p_options)
        //    => p_options.UseSqlServer(@"Server=tcp:moerschel-database.database.windows.net,1433;Initial Catalog=ProjectDatabase;Persist Security Info=False;User ID=ThomasMoerschel;Password=Thomas1203!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        
        protected override void OnModelCreating(ModelBuilder p_modelBuilder)
        {
            p_modelBuilder.Entity<Customer>()
                .Property(cust => cust.Id)
                .ValueGeneratedOnAdd();
            p_modelBuilder.Entity<LineItems>()
                .Property(item => item.Id)
                .ValueGeneratedOnAdd();
            p_modelBuilder.Entity<Orders>()
                .Property(ord => ord.Id)
                .ValueGeneratedOnAdd();
            p_modelBuilder.Entity<Products>()
                .Property(pro => pro.Id)
                .ValueGeneratedOnAdd();
            p_modelBuilder.Entity<StoreFront>()
                .Property(sto => sto.Id)
                .ValueGeneratedOnAdd();
        }
    }
}