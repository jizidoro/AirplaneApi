using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IMrpRegraEstoqueValidation
	{
		Task<ISingleResult<MrpRegraEstoque>> ValidarInclusao(MrpRegraEstoque entity);

		Task<ISingleResult<MrpRegraEstoque>> ValidarEdicao(MrpRegraEstoque entity);

		Task<ISingleResult<MrpRegraEstoque>> ValidarExclusao(int id);
	}
}
