using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using System.Linq;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class IniciadorRepository : Repository<Iniciador>, IIniciadorRepository
	{
		public IniciadorRepository(GestaoEsdContext context)
			: base(context)
		{
		}
	}
}