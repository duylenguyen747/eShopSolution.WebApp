using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Data.Data
{
	public class eShopSolutionDbContextFactory : IDesignTimeDbContextFactory<eShopSolutionDataContext>
	{
		public eShopSolutionDataContext CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var connectionString = configuration.GetConnectionString("eShopSolutionDatabase");

			var optionBuilder = new DbContextOptionsBuilder<eShopSolutionDataContext>();
			optionBuilder.UseSqlServer(connectionString);
			return new eShopSolutionDataContext(optionBuilder.Options);
		}
	}
}
