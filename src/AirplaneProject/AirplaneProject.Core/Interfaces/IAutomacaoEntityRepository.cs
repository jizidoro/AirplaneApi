using AirplaneProject.Domain.Bases;
using System;

namespace AirplaneProject.Core.Interfaces
{
	public interface IAutomacaoEntityRepository<TEntity> : IRepository<TEntity>, IDisposable 
		where TEntity : AutomacaoEntity
    {		
	}
}
