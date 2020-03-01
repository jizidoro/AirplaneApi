using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IMrpValidation
	{
		Task<ISingleResult<Mrp>> ValidarInclusao(Mrp entity);

		Task<ISingleResult<Mrp>> ValidarEdicao(Mrp entity);

		Task<ISingleResult<Mrp>> ValidarExclusao(int id);
	}
}
