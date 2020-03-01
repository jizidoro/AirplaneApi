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
	public class SobressalenteViewRepository : Repository<SobressalenteView>, ISobressalenteViewRepository
	{
		public SobressalenteViewRepository(GestaoEsdContext context)
            : base(context)
        {
		}

		public IQueryable<SobressalenteView> Listar(string unidade, string ativo, string uep, SortByDto orderBy)
		{
			var query = Db.SobressalentesView.AsNoTracking()
					.Where(j =>
						(unidade == null || j.UnidadeNome.Contains(unidade))
						&& (ativo == null || j.AtivoNome.Contains(ativo))
						&& (uep == null || j.UepNome.Contains(uep)))
					.AsQueryable();
			return query;
		}

	}
}
