using ECommerce.EntityLayer.Concrete;
using ECommerce.EntityLayer.Concrete.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Drawing;

namespace ECommerce.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext< AppUser, AppRole, int>
    {

		public Context()
		{
		}

		public Context(DbContextOptions<Context> options) : base(options)
        {
        }



		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				IConfigurationRoot configuration = new ConfigurationBuilder()
				   .SetBasePath(Directory.GetCurrentDirectory())
				   .AddJsonFile("appsettings.json")
				   .Build();
				var connectionString = configuration.GetConnectionString("DbCon");
				optionsBuilder.UseSqlServer(connectionString);

                

            }

            

        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<BodySize> BodySizes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Calor> Colors { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactUs> ContactUss { get; set; }
        public DbSet<Feature> Features { get; set; }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        
        

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderDetails { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
