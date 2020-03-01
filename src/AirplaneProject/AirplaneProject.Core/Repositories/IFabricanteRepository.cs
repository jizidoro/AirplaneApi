using System.Threading.Tasks;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;

namespace AirplaneProject.Core.Repositories
{
	public interface IFabricanteRepository : IRepository<Fabricante>
	{
		Task<ISingleResult<Fabricante>> ExisteMesmoCodigoSap(int id, string codigoSap);
	}
}
