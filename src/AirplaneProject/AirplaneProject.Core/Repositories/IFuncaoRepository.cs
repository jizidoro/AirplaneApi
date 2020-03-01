using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories
{
	public interface IFuncaoRepository : IRepository<Funcao>
    {
        Task<ISingleResult<Funcao>> ObterPorCodigo(string codigo);
    }
}
