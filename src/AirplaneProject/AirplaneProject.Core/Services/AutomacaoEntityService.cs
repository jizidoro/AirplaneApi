using AirplaneProject.Core.Bases;
using AirplaneProject.Core.Extensions;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Domain.Models;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Core.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using AirplaneProject.Domain.Bases;
using System.Linq.Expressions;

namespace AirplaneProject.Core.Services
{
	public class AutomacaoEntityService<TEntity, TChildEntity, TEntityAssociation> : Service, IAutomacaoEntityService<TEntity, TChildEntity, TEntityAssociation>
		where TEntity : AutomacaoEntity
		where TChildEntity : AutomacaoEntity
		where TEntityAssociation : AssociacaoEntity, new()
	{
		private readonly IAutomacaoEntityRepository<TEntity> repository;		
		private readonly IAutomacaoEntityRepository<TChildEntity> repositoryChild;
		private readonly IRepository<TEntityAssociation> repositoryAssociation;
		private readonly IAutomacaoEntityValidation<TEntity> validator;

		public AutomacaoEntityService(IAutomacaoEntityRepository<TEntity> repository,
			IAutomacaoEntityRepository<TChildEntity> repositoryChild,
			IRepository<TEntityAssociation> repositoryAssociation,
			IAutomacaoEntityValidation<TEntity> validator, IUnitOfWork uow)
			: base(uow)
		{
			this.repository = repository;
			this.repositoryChild = repositoryChild;
			this.repositoryAssociation = repositoryAssociation;
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

				var child = await repositoryChild.GetByValue("Não identificado");
				if (child != null)
				{
					var associacao = new TEntityAssociation();

					HydrateAsociationValues(associacao, entity.Id, child.Id);
					await repositoryAssociation.Add(associacao);
				}

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

                foreach (var associacao in validacao.Data.DadosAssociados)
                {
                    repositoryAssociation.Remove(associacao.Id);
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

		private void HydrateAsociationValues(TEntityAssociation associacao, int parentId , int childId)
		{
			var propNameParentId = $"{typeof(TEntity).Name}Id";
			var propNameChildId = $"{typeof(TChildEntity).Name}Id";

			var propParentId = associacao.GetType().GetProperty(propNameParentId);

			if (propParentId != null)
			{
				propParentId.SetValue(associacao, parentId, null);
			}

			var propChildId = associacao.GetType().GetProperty(propNameChildId);

			if (propChildId != null)
			{

				propChildId.SetValue(associacao, childId, null);
			}
		}
	}
}
