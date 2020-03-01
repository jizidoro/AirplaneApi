using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IFabricanteValidation
	{
		Task<ISingleResult<Fabricante>> ValidarInclusao(Fabricante entity);

		Task<ISingleResult<Fabricante>> ValidarEdicao(Fabricante entity);

		Task<ISingleResult<Fabricante>> ValidarExclusao(int id);
	}
}
