using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IUnidadeOperativaService
	{
		Task<ISingleResult<UnidadeOperativa>> Incluir(UnidadeOperativa entity);

		Task<ISingleResult<UnidadeOperativa>> Editar(UnidadeOperativa entity);

		Task<ISingleResult<UnidadeOperativa>> Excluir(int id);
	}
}
