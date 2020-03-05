using AirplaneProject.Core.Bases;
using AirplaneProject.Domain.Bases;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace AirplaneProject.Infrastructure.Extensions
{
	public static class JsonUtilities
	{
		public static List<TTargetModel> GetListFromJson<TTargetModel>(Stream jsonStream)
			where TTargetModel : Entity
		{
			var reader = new StreamReader(jsonStream);
			var jsonString = reader.ReadToEnd();

			var list = JsonConvert.DeserializeObject<List<TTargetModel>>(jsonString);
			
			return list;
		}

		public static TTargetModel[] GetArrayFromJson<TTargetModel>(Stream jsonStream)
			where TTargetModel : Entity
		{
			var reader = new StreamReader(jsonStream);
			var jsonString = reader.ReadToEnd();

			var list = JsonConvert.DeserializeObject<List<TTargetModel>>(jsonString);

			return list.ToArray();
		}
	}
}
