using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IUnidadeOperativaValidation
	{
		Task<ISingleResult<UnidadeOperativa>> ValidarInclusao(UnidadeOperativa entity);

		Task<ISingleResult<UnidadeOperativa>> ValidarEdicao(UnidadeOperativa entity);

		Task<ISingleResult<UnidadeOperativa>> ValidarExclusao(int id);
	}
}
