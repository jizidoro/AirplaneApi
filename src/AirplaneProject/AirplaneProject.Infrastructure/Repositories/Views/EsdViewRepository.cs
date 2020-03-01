using System;
using System.Linq;
using AirplaneProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AirplaneProject.Infrastructure.Bases;
using System.Threading.Tasks;
using AirplaneProject.Core.Repositories.Views;
using AirplaneProject.Core.Extensions;
using AirplaneProject.Domain.Models.Views;
using AirplaneProject.Infrastructure.Extensions;
using AirplaneProject.Domain.Bases;

namespace AirplaneProject.Infrastructure.Repositories.Views
{
    public class EsdViewRepository : Repository<EsdView>, IEsdViewRepository
	{
		public EsdViewRepository(GestaoEsdContext context)
            : base(context)
        {
		}

        public IQueryable<EsdView> ListarPorUnidade(string unidade, string ativo, string uep)
        {
            var x = Db.EsdsView
                    .OrderBy(k => k.DataEvento)
					.Where(j =>
						(unidade == null || j.UnidadeCodigo == unidade)
						&& (ativo == null || j.AtivoCodigo == ativo)
						&& (uep == null || j.UepCodigo == uep))
					.AsNoTracking();

			return x;
        }

        public IQueryable<EsdView> ListarPorPeriodo(string unidade, string ativo, string uep, int top, DateTime? dataInicial, DateTime? dataFinal, string texto, SortByDto orderBy)
        {			
			var query = ListarPorUnidade(unidade, ativo, uep);

            query = query
                    .Where(j => 
						(dataInicial == null || j.DataEvento >= dataInicial)
						&& (dataFinal == null || j.DataEvento <= dataFinal))
                    .AsNoTracking();

			var textoSemAcento = texto.RemoveDiacritics();

			var textosPesquisa = textoSemAcento.SplitTextoPesquisa();

			foreach (var textoPesquisa in textosPesquisa)
			{
				query = query.Where(j => j.DescricaoCodigo.Contains(textoPesquisa, StringComparison.InvariantCultureIgnoreCase));
			}

            if (top > 0)
            {
                query = query.OrderBy(new SortByDto(nameof(EsdView.DataEvento), true));
                query = query.Take(top);
            }

            if (orderBy != null && !string.IsNullOrEmpty(orderBy.Property) && (top == 0 || !orderBy.Property.Equals(nameof(EsdView.DataEvento))))
            {
                query = query.OrderBy(orderBy);
            }

			return query;
        }

		public async Task<EsdView> ObterEvento(int id)
		{
			var evento = await Db.EsdsView
				.Where(p => p.Id == id)
				.Select(p => new EsdView
				{
					AgenteId = p.AgenteId,
					OrigemId = p.OrigemId,
					CausaId = p.CausaId,
					DataEvento = p.DataEvento,
					Descricao = p.Descricao,
					EventoId = p.EventoId,					
					IniciadorId = p.IniciadorId,
					SituacaoId = p.SituacaoId,
					Id = p.Id,
					MotivoId = p.MotivoId,
					NivelId = p.NivelId,
					UepId = p.UepId,
					AtivoId = p.AtivoId,
					Alarme = p.Alarme,
					LinkSitop = p.LinkSitop,
					LinkCadinc = p.LinkCadinc,
					LinkGip = p.LinkGip,
					LinkRta = p.LinkRta,
				})
				.FirstOrDefaultAsync();

			return evento;
		}
    }
}
