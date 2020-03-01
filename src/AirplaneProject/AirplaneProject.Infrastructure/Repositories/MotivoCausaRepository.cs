using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using System.Threading.Tasks;
using System;
using AirplaneProject.Core.Extensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class MotivoCausaRepository : Repository<MotivoCausa>, IMotivoCausaRepository
	{
		public MotivoCausaRepository(GestaoEsdContext context)
			: base(context)
		{
		}

		public async Task<MotivoCausa> ObterPorMotivoCausaNome(string motivoNome, string causaNome)
		{
			if (string.IsNullOrEmpty(motivoNome))
			{
				return null;
			}

			if (string.IsNullOrEmpty(causaNome))
			{
				return null;
			}

			var motivoCodigo = motivoNome.RemoveDiacritics().ToLower();
			var causaCodigo = causaNome.RemoveDiacritics().ToLower();

			var x = await Db.MotivoCausas
					.Where(p =>
						p.Motivo.Codigo == motivoCodigo &&
						p.Causa.Codigo == causaCodigo
					)
					.FirstOrDefaultAsync();

			return x;
		}
	}
}