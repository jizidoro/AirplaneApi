using System;
using System.Linq;
using System.Threading.Tasks;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class ProfissionalRepository : Repository<Profissional>, IProfissionalRepository
	{
		public ProfissionalRepository(GestaoEsdContext context)
			: base(context)
		{			
		}

        public async Task<ISingleResult<Profissional>> ObterPorChave(string chave)
        {
            var obj = await Db.Profissionais
                .Where(p => p.Chave.Equals(chave, System.StringComparison.InvariantCultureIgnoreCase))                
                .FirstOrDefaultAsync();

            return new SingleResult<Profissional>(obj);
        }

		public async Task<ISingleResult<Profissional>> ExisteMesmaChave(int id, string chave)
		{
			var existe = await Db.Profissionais
				.Where(p => p.Id != id
				            && chave.Equals(p.Chave))
				.AnyAsync();

			return existe ? new SingleResult<Profissional>(MensagensNegocio.MSG14) : new SingleResult<Profissional>();
		}
	}
}