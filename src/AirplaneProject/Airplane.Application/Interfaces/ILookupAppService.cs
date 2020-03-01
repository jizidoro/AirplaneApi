using AirplaneProject.Domain.Bases;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirplaneProject.Application.Interfaces
{
	public interface ILookupAppService<TEntity>
		where TEntity : Entity
	{
		Task<IEnumerable<LookupDto>> ObterLookup();
		Task<IEnumerable<LookupDto>> ObterLookup(Expression<Func<TEntity, bool>> predicate);
	}
}
