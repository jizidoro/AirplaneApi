using System;
using System.Linq;
using AirplaneProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AirplaneProject.Infrastructure.Bases;
using System.Threading.Tasks;
using AirplaneProject.Core.Repositories.Views;
using AirplaneProject.Core.Extensions;
using AirplaneProject.Domain.Models.Views;
using System.Linq.Expressions;
using AirplaneProject.Infrastructure.Extensions;
using AirplaneProject.Domain.Bases;

namespace AirplaneProject.Infrastructure.Repositories.Views
{
	public class ConclusaoAlteracaoViewRepository : Repository<ConclusaoAlteracaoView>, IConclusaoAlteracaoViewRepository
	{
		public ConclusaoAlteracaoViewRepository(GestaoEsdContext context)
            : base(context)
        {
		}

        public IQueryable<ConclusaoAlteracaoView> ListarPorUnidade(string unidade, string ativo, string uep)
        {
			var x = Db.ConclusaoAlteracoesView
					.OrderBy(k => k.DataEvento)
					.Where(j =>
						(unidade == null || j.UnidadeCodigo == unidade)
						&& (ativo == null || j.AtivoCodigo == ativo)
						&& (uep == null || j.UepCodigo == uep))
					.AsQueryable();

			return x;
        }

        public IQueryable<ConclusaoAlteracaoView> ObterGridConclusao(string unidade, string ativo, string uep,
	        DateTime? dataInicial, DateTime? dataFinal)
        {
	        var query = ListarPorUnidade(unidade, ativo, uep);
			
	        query = query
		        .Where(j =>
			        (dataInicial == null || j.DataEvento >= dataInicial)
			        && (dataFinal == null || j.DataEvento <= dataFinal))
		        .AsQueryable();


			return query;
		}
    }
}
