using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories
{
	public interface IFinalidadeRepository : IRepository<Finalidade>
    {
        Task<ISingleResult<Finalidade>> ObterPorCodigo(string codigo);
    }
}
