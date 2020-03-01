using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IAirplaneValidation
	{
		Task<ISingleResult<Airplane>> ValidarInclusao(Airplane entity);

		Task<ISingleResult<Airplane>> ValidarEdicao(Airplane entity);

		Task<ISingleResult<Airplane>> ValidarExclusao(int id);
	}
}
