using System.Linq;
using System.Threading.Tasks;
using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class AtivoRepository : Repository<Ativo>, IAtivoRepository
	{
		public AtivoRepository(GestaoEsdContext context)
			: base(context)
		{
		}

		public Ativo ObterPorNome(string ativo)
		{
			var x = Db.Ativos
				.FirstOrDefault(j => (ativo == null || j.Codigo == ativo));
			
			return x;
		}
	}
}