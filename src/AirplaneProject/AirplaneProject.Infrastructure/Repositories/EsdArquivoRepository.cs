using System.Collections.Generic;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Infrastructure.Repositories
{
    public class EsdArquivoRepository : Repository<EsdArquivo>, IEsdArquivoRepository
    {
        public EsdArquivoRepository(GestaoEsdContext context)
            : base(context)
        {
            
        }

        public async Task<EsdArquivo> ObterArquivo(int id)
        {
            var evento = await Db.EsdArquivos
                .Where(p => p.Id == id)
                .Select(p => new EsdArquivo
                {
                    Id = p.Id,
                    EsdId = p.EsdId,
                    NomeArquivo = p.NomeArquivo,
                    Url = p.Url
                })
                .FirstOrDefaultAsync();

            return evento;
        }

        public IQueryable<EsdArquivo> ObterTodosArquivoPorEsd(int esdId)
        {
            var evento = Db.EsdArquivos
                .Where(p => p.EsdId == esdId)
                .Select(p => new EsdArquivo
                {
                    Id = p.Id,
                    EsdId = p.EsdId,
                    NomeArquivo = p.NomeArquivo,
                    Url = p.Url
                }).AsQueryable();

            return evento;
        }
    }
}