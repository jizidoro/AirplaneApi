using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirplaneProject.Domain.Bases;

namespace AirplaneProject.Core.Interfaces
{
	public interface IBaseAutomacaoEntityValidation<TEntity>
		where TEntity : BaseAutomacaoEntity
	{
		Task<ISingleResult<TEntity>> ValidarInclusao(TEntity entity);

		Task<ISingleResult<TEntity>> ValidarEdicao(TEntity entity);

		Task<ISingleResult<TEntity>> ValidarExclusao(int id, Expression<Func<TEntity, bool>> predicate);
	}
}
