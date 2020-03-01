using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using System.Threading.Tasks;
using System.Linq;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Results;
using Microsoft.EntityFrameworkCore;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class CamadaRepository : Repository<Camada>, ICamadaRepository
	{
		public CamadaRepository(GestaoEsdContext context)
			: base(context)
		{			
		}

        public async Task<ISingleResult<Camada>> ObterPorCodigo(string codigo)
        {
            var obj = await Get(x => x.Codigo == codigo);

            return new SingleResult<Camada>(obj);
        }
    }
}