using AirplaneProject.Domain.Bases;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IAssociacaoEntityValidation<TEntity>
		where TEntity : AssociacaoEntity
	{
		Task<ISingleResult<TEntity>> ValidarInclusao(TEntity entity, Expression<Func<TEntity, bool>> predicate);

		Task<ISingleResult<TEntity>> ValidarExclusao(int id);
	}
}
