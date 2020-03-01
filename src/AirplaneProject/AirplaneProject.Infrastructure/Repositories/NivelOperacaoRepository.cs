using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using System.Linq;
using System.Threading.Tasks;
using AirplaneProject.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class NivelOperacaoRepository : Repository<NivelOperacao>, INivelOperacaoRepository
	{
		public NivelOperacaoRepository(GestaoEsdContext context)
			: base(context)
		{
		}

		public async Task<NivelOperacao> ObterPorNivelUep(string nivelNome, Uep uep)
		{
			if (string.IsNullOrEmpty(nivelNome))
			{
				return null;
			}

			if (uep == null)
			{
				return null;
			}

			var nivelCodigo = nivelNome.RemoveDiacritics().ToLower();
			
			var x = await Db.NivelOperacoes
					.Where(p =>
						p.Nivel.Codigo == nivelCodigo &&
						p.OperacaoId == uep.OperacaoId
					)
					.FirstOrDefaultAsync();

			return x;
		}
	}
}