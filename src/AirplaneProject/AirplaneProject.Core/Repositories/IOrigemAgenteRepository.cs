using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories
{
	public interface IOrigemAgenteRepository : IRepository<OrigemAgente>
    {
		Task<OrigemAgente> ObterPorOrigemAgenteNome(string origemNome, string agenteNome);
	}
}
