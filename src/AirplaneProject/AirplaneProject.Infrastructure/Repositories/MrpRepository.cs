using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class MrpRepository : Repository<Mrp>, IMrpRepository
	{
		public MrpRepository(GestaoEsdContext context)
			: base(context)
		{			
		}

        public async Task<Mrp> ObterMrp(string nome)
        {
            var Mrp = await Db.Mrps
                .Where(p => nome.Equals(p.Nome)).Select(p => new Mrp
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Codigo = p.Codigo
                })
                .FirstOrDefaultAsync();

            return Mrp;
        }
    }
}