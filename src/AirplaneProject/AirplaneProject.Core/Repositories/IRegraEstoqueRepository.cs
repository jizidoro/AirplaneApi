using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories
{
	public interface IMrpRegraEstoqueRepository : IRepository<MrpRegraEstoque>
    {
        IQueryable<MrpRegraEstoque> ObterMrpRegraEstoque(int mrpId);
    }
}
