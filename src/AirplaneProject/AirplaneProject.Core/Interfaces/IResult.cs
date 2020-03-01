using AirplaneProject.Domain.Enums;

namespace AirplaneProject.Core.Interfaces
{
	public interface IResult
	{
		EnumResultadoAcao Codigo { get; set; }
		bool Sucesso { get; set; }
		string Mensagem { get; set; }
    }
}
