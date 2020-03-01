using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Bases;
using AirplaneProject.Infrastructure.Data;

namespace AirplaneProject.Infrastructure.Bases
{
	public class AutomacaoEntityRepository<TEntity> : Repository<TEntity>, IAutomacaoEntityRepository<TEntity>
		where TEntity : AutomacaoEntity
	{
		public AutomacaoEntityRepository(GestaoEsdContext context)
			: base(context)
		{			
		}
	}
}
