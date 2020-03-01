using System.Collections.Generic;
using System.Linq;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;

namespace AirplaneProject.Core.Repositories
{
	public interface IHistoricoAlteracaoRepository : IRepository<HistoricoAlteracao>
    {
        IQueryable<HistoricoAlteracao> ObterHistoricoAlteracaosPorAlteracao(int esd);
        
    }
}
