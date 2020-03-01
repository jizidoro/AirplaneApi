using System;
using System.Collections.Generic;
using System.Linq;
using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class HistoricoAlteracaoRepository : Repository<HistoricoAlteracao>, IHistoricoAlteracaoRepository
	{
		public HistoricoAlteracaoRepository(GestaoEsdContext context)
			: base(context)
		{
		}

        public IQueryable<HistoricoAlteracao> ObterHistoricoAlteracaosPorAlteracao(int alteracao)
        {
            var x = Db.HistoricoAlteracoes
                .OrderBy(k => k.DataRegistro)
                .Where(j => j.AlteracaoId == alteracao)
                .AsQueryable();

            return x;
        }
    }
}