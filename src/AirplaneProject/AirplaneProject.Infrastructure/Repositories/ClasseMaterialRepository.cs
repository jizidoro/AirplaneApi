using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class ClasseMaterialRepository : Repository<ClasseMaterial>, IClasseMaterialRepository
	{
		public ClasseMaterialRepository(GestaoEsdContext context)
			: base(context)
		{			
		}
	}
}