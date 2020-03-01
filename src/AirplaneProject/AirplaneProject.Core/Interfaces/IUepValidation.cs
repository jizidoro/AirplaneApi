using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IUepValidation
	{
		Task<ISingleResult<Uep>> ValidarInclusao(Uep entity);

		Task<ISingleResult<Uep>> ValidarEdicao(Uep entity);

		Task<ISingleResult<Uep>> ValidarExclusao(int id);
	}
}
