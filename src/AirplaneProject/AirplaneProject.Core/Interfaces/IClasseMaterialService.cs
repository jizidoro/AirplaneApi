using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IClasseMaterialService
	{
		Task<ISingleResult<ClasseMaterial>> Incluir(ClasseMaterial entity);

		Task<ISingleResult<ClasseMaterial>> Editar(ClasseMaterial entity);

		Task<ISingleResult<ClasseMaterial>> Excluir(int id);
	}
}
