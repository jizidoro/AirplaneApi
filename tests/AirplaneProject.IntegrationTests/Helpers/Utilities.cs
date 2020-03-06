using System.Reflection;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Infrastructure.Extensions;

namespace AirplaneProject.Integration.Tests.Helpers
{
	public static class Utilities
	{
		private const string JSON_PATH = "AirplaneProject.Infrastructure.SeedData";

		#region snippet1
		public static void InitializeDbForTests(AirplaneProjectContext db)
		{
			var assembly = Assembly.GetAssembly(typeof(JsonUtilities));
						
			db.Airplanes.AddRange(JsonUtilities.GetListFromJson<Airplane>(assembly.GetManifestResourceStream($"{JSON_PATH}.airplane.json")));
			
			db.SaveChanges();
		}

		#endregion
	}
}