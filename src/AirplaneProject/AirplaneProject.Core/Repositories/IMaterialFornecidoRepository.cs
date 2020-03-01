using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories
{
    public interface IMaterialFornecidoRepository : IRepository<MaterialFornecido>
    {
        Task<MaterialFornecido> ObterPorCodigoSap(string codigoConsultaSap);
        Task<bool> ExisteMaterialFornecidoComMesmoNM(string NM, int id = 0);
        Task<bool> ExisteMaterialFornecidoComMesmoCodigo(string codigo, int id = 0);
        Task<bool> PossuiMateriaisEstocados(int id);
        Task<MaterialFornecido> ObterMaterialFornecido(int id);
        Task<MaterialFornecido> ObterMaterialFornecido(string NM);
    }
}
