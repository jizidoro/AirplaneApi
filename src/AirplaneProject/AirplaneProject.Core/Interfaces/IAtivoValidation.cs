using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IAtivoValidation
	{
		Task<ISingleResult<Ativo>> ValidarInclusao(Ativo entity);

		Task<ISingleResult<Ativo>> ValidarEdicao(Ativo entity);

		Task<ISingleResult<Ativo>> ValidarExclusao(int id);
	}
}
