using eShopSolution.Data.Configuration;
using eShopSolution.Data.Entities;
using eShopSolution.Data.Extentions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Data.Data
{
	public class eShopSolutionDataContext : IdentityDbContext<AppUser, AppRole, Guid>
	{
		public eShopSolutionDataContext(DbContextOptions options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
			modelBuilder.ApplyConfiguration(new AppUserConfiguration());
			modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
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


			modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
			modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId});
			modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

			modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
			modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

			modelBuilder.Seed();

			//base.OnModelCreating(modelBuilder);
		}



		public DbSet<Product> Products { get; set; }
		public DbSet<Category> categories { get; set; }
		public DbSet<Order> orders { get; set; }
		public DbSet<AppConfig> appConfigs { get; set; }
		public DbSet<Cart> carts { get; set; }
		public DbSet<CategoryTranslation> categoriesTranslation { get; set; }
		public DbSet<Contact> contacts { get; set; }
		public DbSet<Language> languages { get; set; }
		public DbSet<OrderDetail> ordersDetail { get; set; }
		public DbSet<ProductTranslation> productsTranslation { get; set; }
		public DbSet<ProductInCategory> productsInCategory { get; set; }
		public DbSet<Promotion> promotion { get; set; }
		public DbSet<Transaction> transactions { get; set; }
		public DbSet<AppUser> appUsers { get; set; }
		public DbSet<AppRole> appRoles { get; set; }
		public DbSet<Slide> slides { get; set; }
		public DbSet<ProductImages> productImages { get; set; }
	}
}
