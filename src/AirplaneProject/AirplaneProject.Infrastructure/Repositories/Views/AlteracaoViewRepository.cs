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
	public class AlteracaoViewRepository : Repository<AlteracaoView>, IAlteracaoViewRepository
	{
		public AlteracaoViewRepository(GestaoEsdContext context)
            : base(context)
        {
		}

        public IQueryable<AlteracaoView> ListarPorUnidade(string unidade, string ativo, string uep)
        {
			var x = Db.AlteracoesView
					.OrderBy(k => k.DataEvento)
					.Where(j =>
						(unidade == null || j.UnidadeCodigo == unidade)
						&& (ativo == null || j.AtivoCodigo == ativo)
						&& (uep == null || j.UepCodigo == uep))
					.AsNoTracking();

			return x;
        }

        public IQueryable<AlteracaoView> ListarPorPeriodo(string unidade, string ativo, string uep, int top, DateTime? dataInicial, DateTime? dataFinal, string texto, SortByDto orderBy)
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
                query = query.OrderBy(new SortByDto(nameof(AlteracaoView.DataEvento), true));
                query = query.Take(top);
            }

            if (orderBy != null && !string.IsNullOrEmpty(orderBy.Property) && (top == 0 || !orderBy.Property.Equals(nameof(AlteracaoView.DataEvento))))
            {
                query = query.OrderBy(orderBy);
			}
			
			return query;
        }

        public IQueryable<AlteracaoView> ObterGridConclusao(string unidade, string ativo, string uep,
	        DateTime? dataInicial, DateTime? dataFinal)
        {
	        var query = ListarPorUnidade(unidade, ativo, uep);


	        query = query
		        .Where(j =>
			        (dataInicial == null || j.DataEvento >= dataInicial)
			        && (dataFinal == null || j.DataEvento <= dataFinal))
		        .AsNoTracking();

	        return query;
		}

        public async Task<AlteracaoView> ObterEvento(int id)
		{
			var evento = await Db.AlteracoesView
				.Where(p => p.Id == id)
				.Select(p => new AlteracaoView
				{
					DataEvento = p.DataEvento,
					Descricao = p.Descricao,
					Id = p.Id,
					UepId = p.UepId,
					AtivoId = p.AtivoId,
					CamadaId = p.CamadaId,
					FinalidadeId = p.FinalidadeId,
					FuncaoId = p.FuncaoId,
					SistemaId = p.SistemaId,
					SituacaoId = p.SituacaoId,
					SolicitanteId = p.SolicitanteId,
					AprovadorId = p.AprovadorId,
					VerificadorId = p.VerificadorId,
					ExecutorId = p.ExecutorId,
					AutorizadorId = p.AutorizadorId
				})
				.FirstOrDefaultAsync();

			return evento;
		}
    }
}
