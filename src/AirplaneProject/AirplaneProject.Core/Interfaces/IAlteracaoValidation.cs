using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IAlteracaoValidation
	{
		Task<ISingleResult<Alteracao>> ValidarSeExisteEventoParaUnidadeDataHora(Alteracao evento);

		Task<ISingleResult<Alteracao>> ValidarSeExisteEventoParaUnidadeChecksum(Alteracao evento);

		bool VerificarMudanca(Alteracao anterior, Alteracao atual);
		bool VerificarValidacao(Alteracao anterior, Alteracao atual);

		Task<ISingleResult<Alteracao>> ValidarInclusao(Alteracao evento);

		Task<ISingleResult<Alteracao>> ValidarEdicao(Alteracao evento);

		Task<ISingleResult<Alteracao>> ValidarExclusao(int id);
	}
}
