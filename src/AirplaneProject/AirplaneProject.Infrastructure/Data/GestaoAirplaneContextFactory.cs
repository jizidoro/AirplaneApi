using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AirplaneProject.Infrastructure.Data
{
	public class GestaoAirplaneContextFactory : IDesignTimeDbContextFactory<GestaoAirplaneContext>
	{
		public GestaoAirplaneContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<GestaoAirplaneContext>();

			// get the configuration from the app settings
			var config = new ConfigurationBuilder()
			   .SetBasePath(Directory.GetCurrentDirectory())
			   .AddJsonFile("appsettings.Development.json")
			   .Build();

			// define the database to use
			optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

			return new GestaoAirplaneContext(optionsBuilder.Options);
		}
	}
}
