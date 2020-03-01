using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IAtivoService
	{
		Task<ISingleResult<Ativo>> Incluir(Ativo entity);

		Task<ISingleResult<Ativo>> Editar(Ativo entity);

		Task<ISingleResult<Ativo>> Excluir(int id);
	}
}
