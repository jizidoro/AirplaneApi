using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AirplaneProject.Core.Bases;
using AirplaneProject.Core.Extensions;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Domain.Bases;

namespace AirplaneProject.Core.Services
{
	public class BaseAutomacaoEntityService<TEntity> : Service, IBaseAutomacaoEntityService<TEntity>
		where TEntity : BaseAutomacaoEntity
	{
		private readonly IBaseAutomacaoEntityRepository<TEntity> repository;		
		private readonly IBaseAutomacaoEntityValidation<TEntity> validator;

		public BaseAutomacaoEntityService(IBaseAutomacaoEntityRepository<TEntity> repository, IBaseAutomacaoEntityValidation<TEntity> validator, IUnitOfWork uow)
			: base(uow)
		{
			this.repository = repository;
			this.validator = validator;
		}

		public async Task<ISingleResult<TEntity>> Incluir(TEntity entity)
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
				return new SingleResult<TEntity>(MensagensNegocio.MSG07);
			}

			return new InclusaoResult<TEntity>(entity);
		}

		public async Task<ISingleResult<TEntity>> Editar(TEntity entity)
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
				return new SingleResult<TEntity>(ex);
			}

			return new EdicaoResult<TEntity>();
		}

		public async Task<ISingleResult<TEntity>> Excluir(int id, Expression<Func<TEntity, bool>> predicate)
		{
			try
			{
				var validacao = await validator.ValidarExclusao(id, predicate);
				if (!validacao.Sucesso)
				{
					return validacao;
				}

				repository.Remove(id);

				var sucesso = await Commit();
			}
			catch (Exception)
			{
				return new SingleResult<TEntity>(MensagensNegocio.MSG07);
			}

			return new ExclusaoResult<TEntity>();
		}

		private void HydrateValues(TEntity target, TEntity source)
		{
			target.Nome = source.Nome;
			target.Codigo = source.Codigo;
			target.Descricao = source.Descricao;
		}
	}
}
