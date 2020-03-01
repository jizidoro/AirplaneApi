using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories
{
	public interface IAlmoxarifadoRepository : IRepository<Almoxarifado>
	{
		Task<Almoxarifado> ObterAlmoxarifado(string codigoAreaMrp, string codigoCentroMrp);
		Task<ISingleResult<Almoxarifado>> ExisteMesmoCodigoCentroMrp(int id, string codigoCentroMrp);
		Task<ISingleResult<Almoxarifado>> ExisteAssociacoes(int id);
	}
}
