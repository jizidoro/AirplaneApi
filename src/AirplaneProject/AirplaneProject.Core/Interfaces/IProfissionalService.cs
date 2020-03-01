using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IProfissionalService
	{
		Task<ISingleResult<Profissional>> Incluir(Profissional entity);

		Task<ISingleResult<Profissional>> Editar(Profissional entity);

		Task<ISingleResult<Profissional>> Excluir(int id);
	}
}
