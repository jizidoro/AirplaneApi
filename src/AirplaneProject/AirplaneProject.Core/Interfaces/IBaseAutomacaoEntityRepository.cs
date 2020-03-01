using AirplaneProject.Domain.Bases;
using System;

namespace AirplaneProject.Core.Interfaces
{
	public interface IBaseAutomacaoEntityRepository<TEntity> : IRepository<TEntity>, IDisposable 
		where TEntity : BaseAutomacaoEntity
    {		
	}
}
