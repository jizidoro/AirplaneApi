using AirplaneProject.Application.Bases;

namespace AirplaneProject.Application.Dtos
{
	public class AirplaneDto : EntityDto
	{
		public string Nome { get; set; }
		public string Descricao { get; set; }
	}
}
