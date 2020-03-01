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
	public class UnidadeOperativaService : Service, IUnidadeOperativaService
	{
		private readonly IUnidadeOperativaRepository repository;		
		private readonly IUnidadeOperativaValidation validator;

		public UnidadeOperativaService(IUnidadeOperativaRepository repository, IUnidadeOperativaValidation validator, IUnitOfWork uow)
			: base(uow)
		{
			this.repository = repository;
			this.validator = validator;
		}

		public async Task<ISingleResult<UnidadeOperativa>> Incluir(UnidadeOperativa entity)
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
				return new SingleResult<UnidadeOperativa>(MensagensNegocio.MSG07);
			}

			return new InclusaoResult<UnidadeOperativa>(entity);
		}

		public async Task<ISingleResult<UnidadeOperativa>> Editar(UnidadeOperativa entity)
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
				return new SingleResult<UnidadeOperativa>(ex);
			}

			return new EdicaoResult<UnidadeOperativa>();
		}

		public async Task<ISingleResult<UnidadeOperativa>> Excluir(int id)
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
				return new SingleResult<UnidadeOperativa>(MensagensNegocio.MSG07);
			}

			return new ExclusaoResult<UnidadeOperativa>();
		}

		private void HydrateValues(UnidadeOperativa target, UnidadeOperativa source)
		{
			target.Nome = source.Nome;
			target.Codigo = source.Codigo;
			target.Descricao = source.Descricao;
		}
	}
}
