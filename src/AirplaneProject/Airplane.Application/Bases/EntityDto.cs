using AirplaneProject.Application.Interfaces;

namespace AirplaneProject.Application.Bases
{
	public class EntityDto : Dto, IEntityDto, ILookupEntityDto
	{
		public int Id { get; set; }

		public int Key { get; set; }

		public string Value { get; set; }

		public string _ { get; set; }
	}
}
