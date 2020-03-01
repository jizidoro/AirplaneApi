using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories
{
	public interface IMrpRepository : IRepository<Mrp>
    {
        Task<Mrp> ObterMrp(string nome);
    }
}
