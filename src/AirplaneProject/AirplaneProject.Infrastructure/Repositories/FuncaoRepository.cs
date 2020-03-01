using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Core.Interfaces;
using System.Threading.Tasks;
using AirplaneProject.Core.Models.Results;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class FuncaoRepository : Repository<Funcao>, IFuncaoRepository
	{
		public FuncaoRepository(GestaoEsdContext context)
			: base(context)
		{			
		}

        public async Task<ISingleResult<Funcao>> ObterPorCodigo(string codigo)
        {
            var obj = await Get(x => x.Codigo == codigo);

            return new SingleResult<Funcao>(obj);
        }
    }
}