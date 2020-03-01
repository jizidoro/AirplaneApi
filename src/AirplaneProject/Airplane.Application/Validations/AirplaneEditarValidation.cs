using AirplaneProject.Application.Dtos;

namespace AirplaneProject.Application.Validations
{
	public class AirplaneEditarValidation : AirplaneValidation<AirplaneEditarDto>
	{
		public AirplaneEditarValidation()
		{
			ValidarId();
			ValidarNome();
		}
	}
}
