using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;
using AirplaneProject.Core.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Messages;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class AirplaneRepository : Repository<Airplane>, IAirplaneRepository
	{
		public AirplaneRepository(GestaoAirplaneContext context)
			: base(context)
		{
		}

		public async Task<ISingleResult<Airplane>> RegistroComMesmoCodigo(int id, string codigo)
		{
			var existe = await Db.Airplanes
				.Where(p => p.Id != id && p.Codigo.Equals(codigo))
				.AnyAsync();

			return existe ? new SingleResult<Airplane>(MensagensNegocio.MSG08) : new SingleResult<Airplane>();
		}
	}
}