using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IMrpRegraEstoqueService
	{
		Task<ISingleResult<MrpRegraEstoque>> Incluir(MrpRegraEstoque entity);

		Task<ISingleResult<MrpRegraEstoque>> Editar(MrpRegraEstoque entity);

		Task<ISingleResult<MrpRegraEstoque>> Excluir(int id);
	}
}
