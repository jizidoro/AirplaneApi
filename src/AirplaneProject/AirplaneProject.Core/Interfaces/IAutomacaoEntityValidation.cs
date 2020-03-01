using AirplaneProject.Domain.Bases;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IAutomacaoEntityValidation<TEntity>
		where TEntity : AutomacaoEntity
	{
		Task<ISingleResult<TEntity>> ValidarInclusao(TEntity entity);

		Task<ISingleResult<TEntity>> ValidarEdicao(TEntity entity);

		Task<ISingleResult<TEntity>> ValidarExclusao(int id, Expression<Func<TEntity, bool>> predicate);
	}
}
