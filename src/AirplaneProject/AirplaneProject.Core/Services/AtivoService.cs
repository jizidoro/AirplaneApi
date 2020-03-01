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
	public class AtivoService : Service, IAtivoService
	{
		private readonly IAtivoRepository repository;		
		private readonly IAtivoValidation validator;

		public AtivoService(IAtivoRepository repository, IAtivoValidation validator, IUnitOfWork uow)
			: base(uow)
		{
			this.repository = repository;
			this.validator = validator;
		}

		public async Task<ISingleResult<Ativo>> Incluir(Ativo entity)
		{
			try
			{
				entity.Codigo = entity.Nome.ToLower().RemoveDiacritics();
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
				return new SingleResult<Ativo>(MensagensNegocio.MSG07);
			}

			return new InclusaoResult<Ativo>(entity);
		}

		public async Task<ISingleResult<Ativo>> Editar(Ativo entity)
		{
			try
			{
				entity.Codigo = entity.Nome.ToLower().RemoveDiacritics();
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
				return new SingleResult<Ativo>(ex);
			}

			return new EdicaoResult<Ativo>();
		}

		public async Task<ISingleResult<Ativo>> Excluir(int id)
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
				return new SingleResult<Ativo>(MensagensNegocio.MSG07);
			}

			return new ExclusaoResult<Ativo>();
		}

		private void HydrateValues(Ativo target, Ativo source)
		{
			target.UnidadeOperativaId = source.UnidadeOperativaId;
			target.Nome = source.Nome;
			target.Codigo = source.Codigo;
			target.Descricao = source.Descricao;
		}
	}
}
