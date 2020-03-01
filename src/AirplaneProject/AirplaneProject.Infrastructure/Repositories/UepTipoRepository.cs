using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class UepTipoRepository : Repository<UepTipo>, IUepTipoRepository
	{
		public UepTipoRepository(GestaoEsdContext context)
			: base(context)
		{
		}
	}
}