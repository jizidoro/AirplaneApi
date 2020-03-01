using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IFabricanteService
	{
		Task<ISingleResult<Fabricante>> Incluir(Fabricante entity);

		Task<ISingleResult<Fabricante>> Editar(Fabricante entity);

		Task<ISingleResult<Fabricante>> Excluir(int id);
	}
}
