using AirplaneProject.Core.Bases;
using AirplaneProject.Core.Extensions;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Domain.Models;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Services
{
	public class MrpRegraEstoqueService : Service, IMrpRegraEstoqueService
	{
		private readonly IMrpRegraEstoqueRepository repository;		
		private readonly IMrpRegraEstoqueValidation validator;

		public MrpRegraEstoqueService(IMrpRegraEstoqueRepository repository, IMrpRegraEstoqueValidation validator, IUnitOfWork uow)
			: base(uow)
		{
			this.repository = repository;
			this.validator = validator;
		}

		public async Task<ISingleResult<MrpRegraEstoque>> Incluir(MrpRegraEstoque entity)
		{
			try
			{
				var validacao = await validator.ValidarInclusao(entity);
				if (!validacao.Sucesso)
				{
					return validacao;
				}

				await repository.Add(entity);

				var sucesso = await Commit();
			}
			catch (Exception)
			{
				return new SingleResult<MrpRegraEstoque>(MensagensNegocio.MSG07);
			}

			return new InclusaoResult<MrpRegraEstoque>(entity);
		}

		public async Task<ISingleResult<MrpRegraEstoque>> Editar(MrpRegraEstoque entity)
		{
			try
			{
				var result = await validator.ValidarEdicao(entity);
				if (!result.Sucesso)
				{
					return result;
				}

				var obj = result.Data;

				HydrateValues(obj, entity);

				repository.Update(obj);

				var sucesso = await Commit();
			}
			catch (Exception ex)
			{
				return new SingleResult<MrpRegraEstoque>(ex);
			}

			return new EdicaoResult<MrpRegraEstoque>();
		}

		public async Task<ISingleResult<MrpRegraEstoque>> Excluir(int id)
		{
			try
			{
				var validacao = await validator.ValidarExclusao(id);
				if (!validacao.Sucesso)
				{
					return validacao;
				}

				repository.Remove(id);

				var sucesso = await Commit();
			}
			catch (Exception)
			{
				return new SingleResult<MrpRegraEstoque>(MensagensNegocio.MSG07);
			}

			return new ExclusaoResult<MrpRegraEstoque>();
		}

		private void HydrateValues(MrpRegraEstoque target, MrpRegraEstoque source)
		{
			target.Campo = source.Campo;
			target.Operador = source.Operador;
			target.SituacaoRegraEstoque = source.SituacaoRegraEstoque;
			target.Quantidade = source.Quantidade;
		}
	}
}
