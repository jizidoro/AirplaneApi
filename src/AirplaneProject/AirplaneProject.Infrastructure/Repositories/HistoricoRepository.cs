using System;
using System.Collections.Generic;
using System.Linq;
using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class HistoricoRepository : Repository<Historico>, IHistoricoRepository
	{
		public HistoricoRepository(GestaoEsdContext context)
			: base(context)
		{
		}

        public IQueryable<Historico> ObterHistoricosPorEsd(int esd)
        {
            var x = Db.Historicos
                .OrderBy(k => k.DataRegistro)
                .Where(j => j.EsdId == esd)
                .AsQueryable();

            return x;
        }
    }
}