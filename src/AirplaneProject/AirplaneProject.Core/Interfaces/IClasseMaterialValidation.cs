using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IClasseMaterialValidation
	{
		Task<ISingleResult<ClasseMaterial>> ValidarInclusao(ClasseMaterial entity);

		Task<ISingleResult<ClasseMaterial>> ValidarEdicao(ClasseMaterial entity);

		Task<ISingleResult<ClasseMaterial>> ValidarExclusao(int id);
	}
}
