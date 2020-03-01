using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IUepService
	{
		Task<ISingleResult<Uep>> Incluir(Uep entity);

		Task<ISingleResult<Uep>> Editar(Uep entity);

		Task<ISingleResult<Uep>> Excluir(int id);
	}
}
