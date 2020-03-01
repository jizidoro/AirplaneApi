using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using System.Threading.Tasks;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Results;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class FinalidadeRepository : Repository<Finalidade>, IFinalidadeRepository
	{
		public FinalidadeRepository(GestaoEsdContext context)
			: base(context)
		{			
		}

        public async Task<ISingleResult<Finalidade>> ObterPorCodigo(string codigo)
        {
            var obj = await Get(x => x.Codigo == codigo);

            return new SingleResult<Finalidade>(obj);

        }
    }
}