using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Bases;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Infrastructure.Data;

namespace AirplaneProject.Infrastructure.Bases
{
	public class BaseAutomacaoEntityRepository<TEntity> : Repository<TEntity>, IBaseAutomacaoEntityRepository<TEntity>
		where TEntity : BaseAutomacaoEntity
	{
		public BaseAutomacaoEntityRepository(GestaoEsdContext context)
			: base(context)
		{			
		}
	}
}
