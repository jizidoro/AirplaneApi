using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories
{
	public interface ISistemaRepository : IRepository<Sistema>
    {
        Task<ISingleResult<Sistema>> ObterPorCodigo(string codigo);
    }
}
