using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Core.Interfaces;
using System.Threading.Tasks;
using AirplaneProject.Core.Models.Results;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class SistemaRepository : Repository<Sistema>, ISistemaRepository
	{
		public SistemaRepository(GestaoEsdContext context)
			: base(context)
		{
        }

        public async Task<ISingleResult<Sistema>> ObterPorCodigo(string codigo)
        {
            var obj = await Get(x => x.Codigo == codigo);

            return new SingleResult<Sistema>(obj);
        }
    }
}