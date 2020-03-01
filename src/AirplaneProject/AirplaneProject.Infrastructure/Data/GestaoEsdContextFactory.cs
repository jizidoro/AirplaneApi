using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AirplaneProject.Infrastructure.Data
{
	public class GestaoEsdContextFactory : IDesignTimeDbContextFactory<GestaoEsdContext>
	{
		public GestaoEsdContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<GestaoEsdContext>();

			// get the configuration from the app settings
			var config = new ConfigurationBuilder()
			   .SetBasePath(Directory.GetCurrentDirectory())
			   .AddJsonFile("appsettings.Development.json")
			   .Build();

			// define the database to use
			optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

			return new GestaoEsdContext(optionsBuilder.Options);
		}
	}
}
