using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories
{
	public interface IAirplaneRepository : IRepository<Airplane>
    {
		Task<ISingleResult<Airplane>> RegistroComMesmoCodigo(int id, string codigo);
	}
}
