using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Domain.Attributes;
using AirplaneProject.Domain.Bases;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Models.Validations
{
	public class AutomacaoEntityValidation<TEntity> : EntityValidation<TEntity>, IAutomacaoEntityValidation<TEntity>
		where TEntity : AutomacaoEntity
	{
		private readonly IAutomacaoEntityRepository<TEntity> repository;

		public AutomacaoEntityValidation(IAutomacaoEntityRepository<TEntity> repository, IRepository<TEntity> entityRepository)
			: base(entityRepository)
		{
			this.repository = repository;
		}

		public async Task<ISingleResult<TEntity>> ValidarSeExisteMesmoNome(TEntity entity)
		{
			var result = await RegistroComMesmoNome(entity.Id, entity.Nome);
			if (!result.Sucesso)
			{
				return result;
			}

			return new SingleResult<TEntity>();
		}

		public async Task<ISingleResult<TEntity>> ValidarInclusao(TEntity entity)
		{
			return await ValidarSeExisteMesmoNome(entity);
		}

		public async Task<ISingleResult<TEntity>> ValidarEdicao(TEntity entity)
		{
			var registroExiste = await RegistroExiste(entity.Id);
			if (!registroExiste.Sucesso)
			{
				return registroExiste;
            }

            if (registroExiste.Data.Nome.Equals("Não identificado", StringComparison.InvariantCultureIgnoreCase))
            {
                return new SingleResult<TEntity>(MensagensNegocio.MSG11);
            }

            var registroExisteMesmoNome = await ValidarSeExisteMesmoNome(entity);
			if (!registroExisteMesmoNome.Sucesso)
			{
				return registroExisteMesmoNome;
			}

			registroExisteMesmoNome.Data = registroExiste.Data;

			return registroExisteMesmoNome;
		}

		public async Task<ISingleResult<TEntity>> ValidarExclusao(int id, Expression<Func<TEntity, bool>> predicate)
		{
            var include = GetInclude();
            var registroExiste = await RegistroExiste(id, include);
			if (!registroExiste.Sucesso)
			{
				return registroExiste;
			}

            if (registroExiste.Data.Nome.Equals("Não identificado", StringComparison.InvariantCultureIgnoreCase))
            {
                return new SingleResult<TEntity>(MensagensNegocio.MSG12);
            }

			var existeAssociacao = await RegistroComAssociacao(id, predicate);
			if (!existeAssociacao.Sucesso)
			{
				return existeAssociacao;
			}

			return registroExiste;
		}

		public override async Task<ISingleResult<TEntity>> RegistroComAssociacao(int id,
			Expression<Func<TEntity, bool>> predicate,
			string include = null)
		{
			try
			{
				var result = await repository.GetAllChildren(id, predicate, include);
				if (result)
				{
					return new SingleResult<TEntity>(MensagensNegocio.MSG09);
				}

				return new SingleResult<TEntity>();
			}
			catch (Exception ex)
			{
				return new SingleResult<TEntity>(ex);
			}
		}

        private string GetInclude()
        {
            var entityType = typeof(TEntity);
            var entityAttr = entityType.GetCustomAttributes(false).OfType<EntityAttribute>().FirstOrDefault();
            if (entityAttr == null)
            {
                return null;
            }

            return entityAttr.Include;
        }
    }
}
