using System;
using System.Linq;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Infrastructure.Extensions;
using AirplaneProject.Core.Repositories;
using System.Threading.Tasks;
using AirplaneProject.Domain.Bases;
using AirplaneProject.Core.Extensions;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class EsdRepository : Repository<Esd>, IEsdRepository
	{
		public EsdRepository(GestaoEsdContext context)
            : base(context)
        {
		}

        public IQueryable<Esd> ListarPorUnidade(string unidade, string ativo, string uep)
        {
            var x = Db.Esds                    
                    .OrderBy(k => k.DataEvento)
					.Where(j =>
						(unidade == null || j.Uep.Ativo.UnidadeOperativa.Codigo == unidade)
						&& (ativo == null || j.Uep.Ativo.Codigo == ativo)
						&& (uep == null || j.Uep.Codigo == uep))
					.AsQueryable();

			return x;
        }

        public IQueryable<Esd> ListarPorPeriodo(string unidade, string ativo, string uep, int top, DateTime? dataInicial, DateTime? dataFinal, string texto, SortByDto orderBy)
        {
            var query = ListarPorUnidade(unidade, ativo, uep);

            query = query
                    .Where(j =>
                        (dataInicial == null || j.DataEvento >= dataInicial)
                        && (dataFinal == null || j.DataEvento <= dataFinal))
                    .AsQueryable();

            var textoSemAcento = texto.RemoveDiacritics();

            var textosPesquisa = textoSemAcento.SplitTextoPesquisa();

            foreach (var textoPesquisa in textosPesquisa)
            {
                query = query.Where(j => j.DescricaoCodigo.Contains(textoPesquisa, StringComparison.InvariantCultureIgnoreCase));
            }

            if (top > 0)
            {
                query = query.OrderBy(new SortByDto(nameof(Esd.DataEvento), true));
                query = query.Take(top);
            }

            if (orderBy != null && !string.IsNullOrEmpty(orderBy.Property) && (top == 0 || !orderBy.Property.Equals(nameof(Esd.DataEvento))))
            {
                query = query.OrderBy(orderBy);
            }

            return query;
        }

		public async Task<Esd> ObterEvento(int id)
		{
			var evento = await Db.Esds
				.Where(p => p.Id == id)
				.Select(p => new Esd
				{
					OrigemAgenteId = p.OrigemAgenteId,
					OrigemAgente = new OrigemAgente {
						OrigemId = p.OrigemAgente.OrigemId
					},					
					DataEvento = p.DataEvento,
                    Alarme = p.Alarme,
                    LinkSitop = p.LinkSitop,
					LinkCadinc = p.LinkCadinc,
					LinkGip = p.LinkGip,
					LinkRta = p.LinkRta,
					Descricao = p.Descricao,
					EventoIniciador = new EventoIniciador
					{
						EventoId = p.EventoIniciador.EventoId
					},
					EventoIniciadorId = p.EventoIniciadorId,
					Id = p.Id,
					MotivoCausaId = p.MotivoCausaId,
					MotivoCausa = new MotivoCausa
					{
						MotivoId = p.MotivoCausa.MotivoId
					},
					NivelOperacaoId = p.NivelOperacaoId,
					NivelOperacao = new NivelOperacao
					{
						OperacaoId = p.NivelOperacao.OperacaoId
					},
					SituacaoId = p.SituacaoId,
					UepId = p.UepId,
					Uep = new Uep
					{
						AtivoId = p.Uep.AtivoId
					},
					DataRegistro = p.DataRegistro,
					ChaveUsuario = p.ChaveUsuario
				})
				.FirstOrDefaultAsync();

			return evento;
		}

		public async Task<bool> ExisteEventoParaUnidadeDataHora(int id, int uepId, DateTime dataEvento)
		{
			var existe = await Db.Esds
				.Where(p => p.Id != id
					&& p.UepId == uepId
					&& p.DataEvento == dataEvento)
				.AnyAsync();

			return existe;
		}

		public async Task<Esd> ObterUltimoEvento(string unidade, string ativo, string uep)
		{
			var query = ListarPorUnidade(unidade, ativo, uep);

			var ultimoEvento = await query
					.OrderByDescending(p => p.DataEvento)
					.Select(p => new Esd
					{ 
						Id = p.Id,
						DataEvento = p.DataEvento,
						NivelOperacao = new NivelOperacao
						{
							Nivel = new Nivel
							{
								Nome = p.NivelOperacao.Nivel.Nome
							}
						},
						Uep = new Uep
						{
							Nome = p.Uep.Nome
						}
					})
					.FirstOrDefaultAsync();

			return ultimoEvento;
		}
	}
}
