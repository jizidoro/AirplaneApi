using System.Linq;
using System.Threading.Tasks;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class FabricanteRepository : Repository<Fabricante>, IFabricanteRepository
	{
		public FabricanteRepository(GestaoEsdContext context)
			: base(context)
		{			
		}

		public async Task<ISingleResult<Fabricante>> ExisteMesmoCodigoSap(int id, string codigoSap)
		{
			var existe = await Db.Fabricantes
				.Where(p => p.Id != id
				            && p.CodigoSAP == codigoSap)
				.AnyAsync();

			return existe ? new SingleResult<Fabricante>(MensagensNegocio.MSG08) : new SingleResult<Fabricante>();
		}
	}
}