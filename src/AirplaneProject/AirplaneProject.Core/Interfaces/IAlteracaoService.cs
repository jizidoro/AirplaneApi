using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IAlteracaoService
	{
		Task<ISingleResult<Alteracao>> Incluir(Alteracao evento);

		Task<ISingleResult<Alteracao>> Editar(Alteracao evento);

		Task<ISingleResult<Alteracao>> Excluir(int id);
	}
}
