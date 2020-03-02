using AirplaneProject.Application.Dtos;

namespace AirplaneProject.Application.Validations
{
	public class AirplaneIncluirValidation : AirplaneValidation<AirplaneIncluirDto>
	{
		public AirplaneIncluirValidation()
		{
			ValidarCodigo();
			ValidarModelo();
			ValidarQuantidadePassageiros();
		}
	}
}
