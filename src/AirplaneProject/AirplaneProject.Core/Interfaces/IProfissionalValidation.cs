using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IProfissionalValidation
	{
		Task<ISingleResult<Profissional>> ValidarInclusao(Profissional entity);

		Task<ISingleResult<Profissional>> ValidarEdicao(Profissional entity);

		Task<ISingleResult<Profissional>> ValidarExclusao(int id);
	}
}
