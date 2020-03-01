using AirplaneProject.Application.Interfaces;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Bases;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirplaneProject.Application.Services
{
	public class LookupAppService<TEntity> : ILookupAppService<TEntity>
		where TEntity : Entity
	{
		private readonly IRepository<TEntity> repository;

		public LookupAppService(IRepository<TEntity> repository)
		{
			this.repository = repository;
		}

		public async Task<IEnumerable<LookupDto>> ObterLookup()
		{
			var lista = await repository.GetLookup();

			return lista;
		}

		public async Task<IEnumerable<LookupDto>> ObterLookup(Expression<Func<TEntity, bool>> predicate)
		{
			var lista = await repository.GetLookup(predicate);

			return lista;
		}
	}
}
