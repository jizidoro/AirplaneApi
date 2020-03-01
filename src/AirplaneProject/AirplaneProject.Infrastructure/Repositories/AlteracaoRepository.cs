using System;
using System.Linq;
using System.Threading.Tasks;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AirplaneProject.Infrastructure.Repositories
{
    public class AlteracaoRepository : Repository<Alteracao>, IAlteracaoRepository
	{
		public AlteracaoRepository(GestaoEsdContext context)
            : base(context)
        {
		}

		public IQueryable<Alteracao> ListarPorUnidade(string unidade, string ativo, string uep)
		{
			var x = Db.Alteracoes
					.OrderBy(k => k.DataEvento)
					.Where(j =>
						(unidade == null || j.Uep.Ativo.UnidadeOperativa.Codigo == unidade)
						&& (ativo == null || j.Uep.Ativo.Codigo == ativo)
						&& (uep == null || j.Uep.Codigo == uep))
					.AsQueryable();

			return x;
		}

		public async Task<Alteracao> ObterAlteracao(int id)
		{
			var evento = await Db.Alteracoes
				.Where(p => p.Id == id)
				.Select(p => new Alteracao
				{
					Id = p.Id,
					DataEvento = p.DataEvento,
					UepId = p.UepId,
					Uep = new Uep
					{
						AtivoId = p.Uep.AtivoId
					},
					DataRegistro = p.DataRegistro,
					FinalidadeId = p.FinalidadeId,
					CamadaId = p.CamadaId,
					FuncaoId = p.FuncaoId,
					SistemaId = p.SistemaId,
					SituacaoId = p.SituacaoId,
					SolicitanteId = p.SolicitanteId,
                    Solicitante = new Profissional
                    {
                        Chave = p.Solicitante.Chave,
                        Nome = p.Solicitante.Nome
                    },
					ExecutorId = p.ExecutorId,
                    Executor = new Profissional
                    {
                        Chave = p.Executor.Chave,
                        Nome = p.Executor.Nome
                    },
                    AprovadorId = p.AprovadorId,
                    Aprovador = p.Aprovador == null ? null : new Profissional
                    {
                        Chave = p.Aprovador.Chave,
                        Nome = p.Aprovador.Nome
                    },
                    AutorizadorId = p.AutorizadorId,
                    Autorizador = p.Autorizador == null ? null : new Profissional
                    {
                        Chave = p.Autorizador.Chave,
                        Nome = p.Autorizador.Nome
                    },
                    VerificadorId = p.VerificadorId,
                    Verificador = p.Verificador == null ? null : new Profissional
                    {
                        Chave = p.Verificador.Chave,
                        Nome = p.Verificador.Nome
                    },
                    Checksum = p.Checksum,
					Descricao = p.Descricao,
					DescricaoCodigo = p.DescricaoCodigo,
				})
				.FirstOrDefaultAsync();

			return evento;
		}

		public async Task<bool> ExisteEventoParaUnidadeDataHora(int id, int uepId, DateTime dataEvento)
		{
			var existe = await Db.Alteracoes
				.Where(p => p.Id != id
					&& p.UepId == uepId
					&& p.DataEvento == dataEvento)
				.AnyAsync();

			return existe;
		}

		public async Task<bool> ExisteEventoParaUnidadeChecksum(int id, int uepId, string checksum)
		{
			var existe = await Db.Alteracoes
				.Where(p => p.Id != id
				            && p.UepId == uepId
				            && p.Checksum.Equals(checksum))
				.AnyAsync();

			return existe;
		}

		public async Task<Alteracao> ObterUltimoEvento(string unidade, string ativo, string uep)
		{
			var query = ListarPorUnidade(unidade, ativo, uep);

			var ultimoEvento = await query
				.OrderByDescending(p => p.DataEvento)
				.Select(p => new Alteracao
				{
					Id = p.Id,
					DataEvento = p.DataEvento,
					Uep = new Uep
					{
						Nome = p.Uep.Nome
					},
					Finalidade = new Finalidade
					{
						Nome = p.Finalidade.Nome
					},
					Sistema = new Sistema
					{
						Nome = p.Sistema.Nome
					}
				})
				.FirstOrDefaultAsync();

			return ultimoEvento;
		}

	}
}
