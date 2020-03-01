using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories
{
	public interface ICamadaRepository : IRepository<Camada>
    {
        Task<ISingleResult<Camada>> ObterPorCodigo(string codigo);
    }
}
