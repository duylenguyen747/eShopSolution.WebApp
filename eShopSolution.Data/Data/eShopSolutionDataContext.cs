using eShopSolution.Data.Configuration;
using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Data.Data
{
	public class eShopSolutionDataContext : DbContext
	{
		public eShopSolutionDataContext(DbContextOptions options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
			modelBuilder.ApplyConfiguration(new CartConfiguration());
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());
			modelBuilder.ApplyConfiguration(new ContactConfiguration());
			modelBuilder.ApplyConfiguration(new LanguageConfiguration());
			modelBuilder.ApplyConfiguration(new OrderConfiguration());
			modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
			modelBuilder.ApplyConfiguration(new ProductTranslationConfiguration());
			modelBuilder.ApplyConfiguration(new PromotionConfiguration());
			modelBuilder.ApplyConfiguration(new TransactionConfiguration());
			base.OnModelCreating(modelBuilder);
		}



		public DbSet<Product> products { get; set; }
		public DbSet<Category> categories { get; set; }
		public DbSet<Order> orders { get; set; }
		public DbSet<AppConfig> appConfigs { get; set; }
		public DbSet<Cart> carts { get; set; }
		public DbSet<CategoryTranslation> categoriesTranslation { get; set; }
		public DbSet<Contact> contacts { get; set; }
		public DbSet<Language> languages { get; set; }
		public DbSet<OrderDetail> ordersDetail { get; set; }
		public DbSet<ProductTranslation> productsTranslation { get; set; }
		public DbSet<Promotion> promotion { get; set; }
		public DbSet<Transaction> transactions { get; set; }
	}
}
