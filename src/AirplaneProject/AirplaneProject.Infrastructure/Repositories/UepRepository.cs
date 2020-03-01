using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using System.Linq;
using AirplaneProject.Domain.Models;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class UepRepository : Repository<Uep>, IUepRepository
	{
		public UepRepository(GestaoEsdContext context)
			: base(context)
		{
		}

		public Uep ObterPorNome(string uep)
		{
			var x = Db.Ueps
				.FirstOrDefault(j => (uep == null || j.Codigo == uep));

			return x;
		}
	}
}