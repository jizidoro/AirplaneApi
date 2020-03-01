using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class UepAlmoxarifadoRepository : Repository<UepAlmoxarifado>, IUepAlmoxarifadoRepository
	{
		public UepAlmoxarifadoRepository(GestaoEsdContext context)
			: base(context)
		{			
		}
	}
}