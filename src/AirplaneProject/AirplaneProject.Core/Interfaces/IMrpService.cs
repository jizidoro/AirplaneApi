using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IMrpService
	{
		Task<ISingleResult<Mrp>> Incluir(Mrp entity);

		Task<ISingleResult<Mrp>> Editar(Mrp entity);

		Task<ISingleResult<Mrp>> Excluir(int id);
	}
}
