using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class MotivoRepository : Repository<Motivo>, IMotivoRepository
	{
		public MotivoRepository(GestaoEsdContext context)
			: base(context)
		{
		}
	}
}