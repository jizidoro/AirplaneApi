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
	public class SituacaoMaterialRepository : Repository<SituacaoMaterial>, ISituacaoMaterialRepository
	{
		public SituacaoMaterialRepository(GestaoEsdContext context)
			: base(context)
		{			
		}

		public async Task<ISingleResult<SituacaoMaterial>> ObterPorCodigo(string codigo)
		{
			var obj = await Db.SituacaoMateriais
				.Where(p => p.Codigo.Equals(codigo))
				.FirstOrDefaultAsync();

			return new SingleResult<SituacaoMaterial>(obj);
		}
	}
}