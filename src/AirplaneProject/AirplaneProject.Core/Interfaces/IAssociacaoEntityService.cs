using AirplaneProject.Domain.Bases;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IAssociacaoEntityService<TEntity>
		where TEntity : AssociacaoEntity
	{
		Task<ISingleResult<TEntity>> Incluir(TEntity entity, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> projection);

		Task<ISingleResult<TEntity>> Excluir(int id);
	}
}
