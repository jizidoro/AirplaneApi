using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IEsdValidation
	{
		Task<ISingleResult<Esd>> ValidarSeExisteEventoParaUnidadeDataHora(Esd evento);

		bool VerificarMudanca(Esd anterior, Esd atual);

		bool VerificarValidacao(Esd anterior, Esd atual);

		Task<ISingleResult<Esd>> ValidarInclusao(Esd evento);

		Task<ISingleResult<Esd>> ValidarEdicao(Esd evento);

		Task<ISingleResult<Esd>> ValidarExclusao(int id);

	}
}
