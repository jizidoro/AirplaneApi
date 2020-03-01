using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories
{
	public interface ISituacaoMaterialRepository : IRepository<SituacaoMaterial>
    {
        Task<ISingleResult<SituacaoMaterial>> ObterPorCodigo(string codigo);
    }
}
