using System.Collections.Generic;
using System.Linq;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories
{
    public interface IEsdArquivoRepository : IRepository<EsdArquivo>
    {
        Task<EsdArquivo> ObterArquivo(int id);
        IQueryable<EsdArquivo> ObterTodosArquivoPorEsd(int esdId);
    }
}