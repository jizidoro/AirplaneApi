using AirplaneProject.Application.Bases;
using AirplaneProject.Application.Dtos;

namespace AirplaneProject.Application.Validations
{
	public class AirplaneExcluirValidation : DtoValidation<AirplaneExcluirDto>
	{
		public AirplaneExcluirValidation()
		{
			ValidarId();
		}
	}
}
