using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using System.Linq;
using System.Threading.Tasks;
using AirplaneProject.Core.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class OrigemAgenteRepository : Repository<OrigemAgente>, IOrigemAgenteRepository
	{
		public OrigemAgenteRepository(GestaoEsdContext context)
			: base(context)
		{
		}

		public async Task<OrigemAgente> ObterPorOrigemAgenteNome(string origemNome, string agenteNome)
		{
			if (string.IsNullOrEmpty(origemNome))
			{
				return null;
			}

			if (string.IsNullOrEmpty(agenteNome))
			{
				return null;
			}

			var origemCodigo = origemNome.RemoveDiacritics().ToLower();
			var agenteCodigo = agenteNome.RemoveDiacritics().ToLower();

			var x = await Db.OrigemAgentes
					.Where(p =>
						p.Origem.Codigo == origemCodigo &&
						p.Agente.Codigo == agenteCodigo
					)
					.FirstOrDefaultAsync();

			return x;
		}
	}
}