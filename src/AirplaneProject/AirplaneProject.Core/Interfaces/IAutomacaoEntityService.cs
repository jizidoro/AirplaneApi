using AirplaneProject.Domain.Bases;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IAutomacaoEntityService<TEntity, TChildEntity, TEntityAssociation>
		where TEntity : AutomacaoEntity
		where TChildEntity : AutomacaoEntity
		where TEntityAssociation : AssociacaoEntity, new()
	{
		Task<ISingleResult<TEntity>> Incluir(TEntity entity);

		Task<ISingleResult<TEntity>> Editar(TEntity entity);

		Task<ISingleResult<TEntity>> Excluir(int id, Expression<Func<TEntity, bool>> predicate);
	}
}
