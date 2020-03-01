using System.Threading.Tasks;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;

namespace AirplaneProject.Core.Repositories
{
	public interface ISituacaoRepository : IRepository<Situacao>
	{
		Task<ISingleResult<Situacao>> ObterPorCodigo(string codigo);
	}
}
