using AirplaneProject.Core.Bases;
using AirplaneProject.Core.Extensions;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using AirplaneProject.Core.Models.Dtos;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Services
{
	public class EsdService : Service, IEsdService
	{
		private readonly IEsdRepository repository;
		private readonly IHistoricoRepository historicoRepository;
		private readonly ISituacaoRepository situacaoRepository;
		private readonly IEsdValidation validator;

		public EsdService(IEsdRepository repository, IHistoricoRepository historicoRepository, ISituacaoRepository situacaoRepository, IEsdValidation validator, IUnitOfWork uow)
			: base(uow)
		{
			this.repository = repository;
			this.historicoRepository = historicoRepository;
			this.situacaoRepository = situacaoRepository;
			this.validator = validator;
		}

		public async Task<ISingleResult<Esd>> Incluir(Esd evento)
		{
			var validacao = await validator.ValidarInclusao(evento);
			if (!validacao.Sucesso)
			{
				return validacao;
			}

			try
			{
				evento.DataRegistro = DateTime.Now;

				var situacaoPadrao = await situacaoRepository.ObterPorCodigo(Situacao.CodigoPadrao);

				evento.SituacaoId = situacaoPadrao.Data.Id;

				AtribuirCodigos(evento);

				await repository.Add(evento);

				await CriarHistorico(evento);

				var sucesso = await Commit();
			}
			catch (Exception ex)
			{
				return new SingleResult<Esd>(ex);
			}

			return new InclusaoResult<Esd>(evento);
		}

		public async Task<ISingleResult<Esd>> Editar(Esd evento)
		{
			var result = await validator.ValidarEdicao(evento);
			if (!result.Sucesso)
			{
				return result;
			}

			if (validator.VerificarMudanca(result.Data, evento))
			{
				return new EdicaoResult<Esd>();
			}

			if (validator.VerificarValidacao(result.Data, evento))
			{
				var situacaoPadrao = await situacaoRepository.ObterPorCodigo(Situacao.CodigoPadrao);

				evento.SituacaoId = situacaoPadrao.Data.Id;
			}

			try
			{
				var entity = result.Data;

				HydrateValues(entity, evento);

				repository.Update(entity);

				await CriarHistorico(entity);

				var sucesso = await Commit();
			}
			catch (Exception ex)
			{
				return new SingleResult<Esd>(ex);
			}

			return new EdicaoResult<Esd>();
		}

		public async Task<ISingleResult<Esd>> Excluir(int id)
		{
			var validacao = await validator.ValidarExclusao(id);
			if (!validacao.Sucesso)
			{
				return validacao;
			}

			try
			{                
                foreach (var historico in validacao.Data.Historicos)
                {
                    historicoRepository.Remove(historico.Id);
                }
				repository.Remove(id);

				var sucesso = await Commit();
			}
			catch (Exception ex)
			{
				return new SingleResult<Esd>(ex);
			}

			return new ExclusaoResult<Esd>();
		}

		public int CalcularDiasSemEsd(Esd ultimoEvento)
		{
			var diasSemEsd = 0;
			if (ultimoEvento != null)
			{
				diasSemEsd = (int)DateTime.Now.Subtract(ultimoEvento.DataEvento).TotalDays;
			}

			return diasSemEsd;
		}

		public int CalcularRecorde(IList<EsdListaEncadeadaPorDataDto> lista, Esd ultimoEvento)
		{
			this.EncadearEventos(lista);
			if (ultimoEvento != null)
			{
				lista.Add(new EsdListaEncadeadaPorDataDto { DataAnterior = ultimoEvento.DataEvento });
			}

			var recorde = 0;
			var maiorPeriodoSemEsd = lista.OrderByDescending(e => e.DiasSemEsd).FirstOrDefault();			
			if (maiorPeriodoSemEsd != null)
			{
				recorde = maiorPeriodoSemEsd.DiasSemEsd;
			}

			return recorde;
		}

		private void EncadearEventos(IList<EsdListaEncadeadaPorDataDto> eventos)
		{
			for (int i = 0; i < eventos.Count; i++)
			{
				if (i > 0)
				{
					eventos[i].DataAnterior = eventos[i - 1].DataAtual;
				}
			}			
		}

		private void HydrateValues(Esd target, Esd source)
		{
			target.OrigemAgenteId = source.OrigemAgenteId;			
			target.DataEvento = source.DataEvento;
            target.Alarme = source.Alarme;
            target.LinkSitop = source.LinkSitop;
			target.LinkCadinc = source.LinkCadinc;
			target.LinkGip = source.LinkGip;
			target.LinkRta = source.LinkRta;
			target.Descricao = source.Descricao;
			AtribuirCodigos(target, source);
			target.EventoIniciadorId = source.EventoIniciadorId;
			target.MotivoCausaId = source.MotivoCausaId;
			target.NivelOperacaoId = source.NivelOperacaoId;
			target.UepId = source.UepId;
			target.SituacaoId = source.SituacaoId;
			target.DataRegistro = DateTime.Now;
            target.NomeUsuario = source.NomeUsuario;
            target.ChaveUsuario = source.ChaveUsuario;
		}

		private async Task CriarHistorico(Esd source)
		{
			var target = new Historico();

			target.Esd = source;
            
			target.OrigemAgenteId = source.OrigemAgenteId;
			target.DataEvento = source.DataEvento;
			target.Descricao = source.Descricao;
			target.Alarme = source.Alarme;
			target.LinkSitop = source.LinkSitop;
			target.LinkCadinc = source.LinkCadinc;
			target.LinkGip = source.LinkGip;
			target.LinkRta = source.LinkRta;
			target.DescricaoCodigo = source.DescricaoCodigo;
			target.EventoIniciadorId = source.EventoIniciadorId;
			target.MotivoCausaId = source.MotivoCausaId;
			target.NivelOperacaoId = source.NivelOperacaoId;
			target.UepId = source.UepId;
			target.SituacaoId = source.SituacaoId;
			target.ChaveUsuario = source.ChaveUsuario;
            target.NomeUsuario = source.NomeUsuario;
            target.DataRegistro = source.DataRegistro; 
			target.DataAlteracao = DateTime.Now;

			await historicoRepository.Add(target);
		}

		private void AtribuirCodigos(Esd target)
		{
			AtribuirCodigos(target, target);
		}

		private void AtribuirCodigos(Esd target, Esd source)
		{
			if (!string.IsNullOrEmpty(source.Descricao))
			{
				target.DescricaoCodigo = source.Descricao.RemoveDiacritics();
				target.DescricaoCodigo = target.DescricaoCodigo.ToLower();
			}

			if (!string.IsNullOrEmpty(source.Alarme))
			{
				target.AlarmeCodigo = source.Alarme.RemoveDiacritics();
				target.AlarmeCodigo = target.Alarme.ToLower();
			}
		}
    }
}
