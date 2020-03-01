using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirplaneProject.Domain.Bases;

namespace AirplaneProject.Core.Interfaces
{
	public interface IBaseAutomacaoEntityService<TEntity>
		where TEntity : BaseAutomacaoEntity
	{
		Task<ISingleResult<TEntity>> Incluir(TEntity entity);

		Task<ISingleResult<TEntity>> Editar(TEntity entity);

		Task<ISingleResult<TEntity>> Excluir(int id, Expression<Func<TEntity, bool>> predicate);
	}
}
