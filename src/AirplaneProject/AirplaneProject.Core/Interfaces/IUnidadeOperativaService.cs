using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IAirplaneService
	{
		Task<ISingleResult<Airplane>> Incluir(Airplane entity);

		Task<ISingleResult<Airplane>> Editar(Airplane entity);

		Task<ISingleResult<Airplane>> Excluir(int id);
	}
}
