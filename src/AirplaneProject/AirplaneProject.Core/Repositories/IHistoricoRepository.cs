using System.Collections.Generic;
using System.Linq;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;

namespace AirplaneProject.Core.Repositories
{
	public interface IHistoricoRepository : IRepository<Historico>
    {
        IQueryable<Historico> ObterHistoricosPorEsd(int esd);
        
    }
}
