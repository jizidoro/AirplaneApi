using AirplaneProject.Core.Bases;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Core.Models.Results;
using System;
using System.Threading.Tasks;
using AirplaneProject.Domain.Bases;
using System.Linq.Expressions;

namespace AirplaneProject.Core.Services
{
	public class AssociacaoEntityService<TEntity> : Service, IAssociacaoEntityService<TEntity>
		where TEntity : AssociacaoEntity
	{
		private readonly IRepository<TEntity> repository;		
		private readonly IAssociacaoEntityValidation<TEntity> validator;

		public AssociacaoEntityService(IRepository<TEntity> repository, IAssociacaoEntityValidation<TEntity> validator, IUnitOfWork uow)
			: base(uow)
		{
			this.repository = repository;
			this.validator = validator;
		}

		public async Task<ISingleResult<TEntity>> Incluir(TEntity entity, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> projection)
		{	
			try
			{
				var validacao = await validator.ValidarInclusao(entity, predicate);
				if (!validacao.Sucesso)
				{
					return validacao;
				}

				await repository.Add(entity);

				var sucesso = await Commit();

				var obj = await repository.GetById(entity.Id, projection);

				return new InclusaoResult<TEntity>(obj);
			}
			catch (Exception)
			{
				return new SingleResult<TEntity>(MensagensNegocio.MSG07);
			}
		}

		public async Task<ISingleResult<TEntity>> Excluir(int id)
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

				return new ExclusaoResult<TEntity>();
			}
			catch (Exception)
			{
				return new SingleResult<TEntity>(MensagensNegocio.MSG07);
			}
		}
	}
}
