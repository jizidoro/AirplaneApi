using AirplaneProject.Core.Bases;
using AirplaneProject.Core.Extensions;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Services
{
    public class AlteracaoService : Service, IAlteracaoService
	{
		private readonly IAlteracaoRepository repository;
		private readonly IHistoricoAlteracaoRepository historicoAlteracaoRepository;
        private readonly IProfissionalRepository profissionalRepository;
        private readonly ISituacaoRepository situacaoRepository;
		private readonly IAlteracaoValidation validator;
		private readonly IUser aspNetUser;

		public AlteracaoService(IAlteracaoRepository repository, IHistoricoAlteracaoRepository historicoAlteracaoRepository, 
                IProfissionalRepository profissionalRepository, ISituacaoRepository situacaoRepository, IAlteracaoValidation validator, 
				IUnitOfWork uow, IUser user)
			: base(uow)
		{
			this.repository = repository;
			this.historicoAlteracaoRepository = historicoAlteracaoRepository;
            this.profissionalRepository = profissionalRepository;
            this.situacaoRepository = situacaoRepository;
			this.validator = validator;
			this.aspNetUser = user;
		}

		public async Task<ISingleResult<Alteracao>> Incluir(Alteracao alteracao)
		{
			var validacao = await validator.ValidarInclusao(alteracao);
			if (!validacao.Sucesso)
			{
				return validacao;
			}

			try
			{
				alteracao.DataRegistro = DateTime.Now;

				AtribuirCodigos(alteracao);
                TratarProfissionais(alteracao);
                AdicionarProfissionais(alteracao);
				await repository.Add(alteracao);

				await CriarHistorico(alteracao);

				var sucesso = await Commit();
			}
			catch (Exception ex)
			{
				return new SingleResult<Alteracao>(ex);
			}

			return new InclusaoResult<Alteracao>(alteracao);
		}

		public async Task<ISingleResult<Alteracao>> Editar(Alteracao alteracao)
		{
			var result = await validator.ValidarEdicao(alteracao);

			if (!result.Sucesso)
			{
				return result;
			}

			var verificaMudanca = validator.VerificarMudanca(result.Data, alteracao);

			if (verificaMudanca)
			{
				return new EdicaoResult<Alteracao>();
			}

			if (validator.VerificarValidacao(result.Data, alteracao))
			{
				var dbSituacaoEmAnalise = await situacaoRepository.ObterPorCodigo("em analise");
				alteracao.SituacaoId = dbSituacaoEmAnalise.Data.Id;
			}


			try
			{

				var entity = result.Data;
				
				HydrateValues(entity, alteracao);
                
                repository.Update(entity);

				await CriarHistorico(entity);

				var sucesso = await Commit();
			}
			catch (Exception ex)
			{
				return new SingleResult<Alteracao>(ex);
			}

			return new EdicaoResult<Alteracao>();
		}

		public async Task<ISingleResult<Alteracao>> Excluir(int id)
		{
			var validacao = await validator.ValidarExclusao(id);
			if (!validacao.Sucesso)
			{
				return validacao;
			}

			try
			{                
                foreach (var historico in validacao.Data.HistoricoAlteracoes)
                {
                    historicoAlteracaoRepository.Remove(historico.Id);
                }
				repository.Remove(id);

				var sucesso = await Commit();
			}
			catch (Exception ex)
			{
				return new SingleResult<Alteracao>(ex);
			}

			return new ExclusaoResult<Alteracao>();
		}
		
		private void HydrateValues(Alteracao target, Alteracao source)
		{
			target.UepId = source.UepId;
			target.CamadaId = source.CamadaId;
			target.FinalidadeId = source.FinalidadeId;
			target.FuncaoId = source.FuncaoId;
			target.SistemaId = source.SistemaId;
			target.SituacaoId = source.SituacaoId;

			AtribuirCodigos(target, source);
			
			target.DataEvento = source.DataEvento;
			target.DataRegistro = DateTime.Now;
			target.Checksum = source.Checksum;
			target.Descricao = source.Descricao;

			target.AprovadorId = source.AprovadorId;
			target.AutorizadorId = source.AutorizadorId;
			target.ExecutorId = source.ExecutorId;
			target.SolicitanteId = source.SolicitanteId;
			target.VerificadorId = source.VerificadorId;
            target.Aprovador = source.Aprovador;
            target.Autorizador = source.Autorizador;
            target.Executor = source.Executor;
            target.Solicitante = source.Solicitante;
            target.Verificador = source.Verificador;

            TratarRetirarProfissionais(target);
			TratarProfissionais(target);
            
			AdicionarProfissionais(target);
        }

		private async Task CriarHistorico(Alteracao source)
		{
			var target = new HistoricoAlteracao();

			target.Alteracao = source;

			target.UepId = source.UepId;
			target.CamadaId = source.CamadaId;
			target.FinalidadeId = source.FinalidadeId;
			target.FuncaoId = source.FuncaoId;
			target.SistemaId = source.SistemaId;
			target.SituacaoId = source.SituacaoId;

			target.DataEvento = source.DataEvento;
			target.DataRegistro = DateTime.Now;
			target.Checksum = source.Checksum;
			target.Descricao = source.Descricao;

			target.AprovadorId = source.AprovadorId;
			target.AutorizadorId = source.AutorizadorId;
			target.ExecutorId = source.ExecutorId;
			target.SolicitanteId = source.SolicitanteId;
			target.VerificadorId = source.VerificadorId;
            target.Aprovador = source.Aprovador;
            target.Autorizador = source.Autorizador;
            target.Executor = source.Executor;
            target.Solicitante = source.Solicitante;
            target.Verificador = source.Verificador;

            target.NomeUsuario = source.NomeUsuario;
			target.ChaveUsuario = source.ChaveUsuario;

			await historicoAlteracaoRepository.Add(target);
		}

		private void AtribuirCodigos(Alteracao target)
		{
			AtribuirCodigos(target, target);
		}

		private void AtribuirCodigos(Alteracao target, Alteracao source)
		{
			if (!string.IsNullOrEmpty(source.Descricao))
			{
				target.DescricaoCodigo = source.Descricao.RemoveDiacritics();
				target.DescricaoCodigo = target.DescricaoCodigo.ToLower();
			}
		}

        private void TratarProfissionais(Alteracao alteracao)
        {
            if (alteracao.SolicitanteId > 0)
            {
                alteracao.Solicitante = null;
            }

            if (alteracao.ExecutorId > 0)
            {
                alteracao.Executor = null;
            }

            if (alteracao.AprovadorId > 0)
            {
                alteracao.Aprovador = null;
            }

            if (alteracao.AutorizadorId > 0)
            {
                alteracao.Autorizador = null;
            }

            if (alteracao.VerificadorId > 0)
            {
                alteracao.Verificador = null;
            }
        }

        private void TratarRetirarProfissionais(Alteracao alteracao)
        {
			if (alteracao.Aprovador != null && string.IsNullOrEmpty(alteracao.Aprovador.Chave))
	        {
		        alteracao.Aprovador = null;
		        alteracao.AprovadorId = null;
	        }

			if (alteracao.Autorizador != null && string.IsNullOrEmpty(alteracao.Autorizador.Chave))
	        {
		        alteracao.Autorizador = null;
		        alteracao.AutorizadorId = null;
	        }

			if (alteracao.Verificador != null && string.IsNullOrEmpty(alteracao.Verificador.Chave))
	        {
		        alteracao.Verificador = null;
		        alteracao.VerificadorId = null;
			}
        }

		private void AdicionarProfissionais(Alteracao alteracao)
        {
			Dictionary<string,Profissional> listaChaves = new Dictionary<string, Profissional>();

			if (alteracao.SolicitanteId == 0 && alteracao.Solicitante != null && alteracao.Solicitante.Id == 0)
			{
				alteracao.Solicitante = IncluirProfissional(alteracao.Solicitante, listaChaves);
			}

			if (alteracao.ExecutorId == 0 && alteracao.Executor != null && alteracao.Executor.Id == 0)
			{
				alteracao.Executor = IncluirProfissional(alteracao.Executor, listaChaves);
			}

			if (alteracao.AutorizadorId == 0 && alteracao.Autorizador != null && alteracao.Autorizador.Id == 0)
			{
				alteracao.Autorizador = IncluirProfissional(alteracao.Autorizador, listaChaves);
			}

			if (alteracao.AprovadorId == 0 && alteracao.Aprovador != null && alteracao.Aprovador.Id == 0)
			{
				alteracao.Aprovador = IncluirProfissional(alteracao.Aprovador, listaChaves);
			}

			if (alteracao.VerificadorId == 0 && alteracao.Verificador != null && alteracao.Verificador.Id == 0)
			{
				alteracao.Verificador = IncluirProfissional(alteracao.Verificador, listaChaves);
			}
		}

		private Profissional IncluirProfissional(Profissional profissional, Dictionary<string, Profissional> listaChaves)
		{
			if (!listaChaves.ContainsKey(profissional.Chave))
			{
				listaChaves.Add(profissional.Chave, profissional);
				profissionalRepository.Add(profissional);
				return profissional;
			}

			return listaChaves.TryGetValue(profissional.Chave, out var value) ? value : null;
		}
	}
}
