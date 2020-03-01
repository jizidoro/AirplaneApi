using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Domain.Bases;

namespace AirplaneProject.Core.Models.Validations
{
	public class BaseAutomacaoEntityValidation<TEntity> : EntityValidation<TEntity>, IBaseAutomacaoEntityValidation<TEntity>
		where TEntity : BaseAutomacaoEntity
	{
		private readonly IBaseAutomacaoEntityRepository<TEntity> repository;

		public BaseAutomacaoEntityValidation(IBaseAutomacaoEntityRepository<TEntity> repository, IRepository<TEntity> entityRepository)
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
			var registroExiste = await RegistroExiste(id);
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

			return new SingleResult<TEntity>();
		}

		public override async Task<ISingleResult<TEntity>> RegistroComAssociacao(int id, Expression<Func<TEntity, bool>> predicate, string include = null)
		{
			try
			{
				var result = await repository.ChildrenExists(id, predicate, include);
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
	}
}
