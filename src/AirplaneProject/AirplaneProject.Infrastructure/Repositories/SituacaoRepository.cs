using System.Linq;
using System.Threading.Tasks;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class SituacaoRepository : Repository<Situacao>, ISituacaoRepository
	{
		public SituacaoRepository(GestaoEsdContext context)
			: base(context)
		{			
		}

		public async Task<ISingleResult<Situacao>> ObterPorCodigo(string codigo)
		{
			var obj = await Get(x => x.Codigo == codigo);

            return new SingleResult<Situacao>(obj);
        }
	}
}