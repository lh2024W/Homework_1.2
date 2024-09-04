using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Homework_1._2
{
    public class DatabaseProduct
    {
        private DbContextOptions<ApplicationContext> GetConnectionOptions()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            return optionsBuilder.UseSqlServer(connectionString).Options;
        }

        public void EnsurePopulate()
        {
            using (ApplicationContext db = new ApplicationContext(GetConnectionOptions()))
            {
                //db.Database.EnsureCreated();
                
            }
        }
        
        public void PrintProducts() 
        {
            using (ApplicationContext db = new ApplicationContext(GetConnectionOptions()))
            {
                List<Product> products = db.Products.ToList();
            }
        }

        public void AddProduct(Product product)
        {
            using (ApplicationContext db = new ApplicationContext(GetConnectionOptions()))
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (ApplicationContext db = new ApplicationContext(GetConnectionOptions()))
            {
                db.Products.Update(product);
                db.SaveChanges();
            }
        }
    }
    class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            
        }
    }
    public class Program
    {
        static void Main()
        {
            DatabaseProduct dbProduct = new DatabaseProduct();
            dbProduct.EnsurePopulate();
            dbProduct.PrintProducts();

            Product product = new Product
            {
                Name = "Test",
                IdCategory = 1,
                Price = 1,
                Quantity = 1,
                IdProducer = 1,
                IdMeasurement = 1,
                IdMarkup = 1
            };
            dbProduct.AddProduct(product);
            dbProduct.Update(product);
            dbProduct.PrintProducts();
        }

            

    }
}




    
