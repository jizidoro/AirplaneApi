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
    public class AlmoxarifadoRepository : Repository<Almoxarifado>, IAlmoxarifadoRepository
    {
        public AlmoxarifadoRepository(GestaoEsdContext context)
            : base(context)
        {
        }

        public async Task<Almoxarifado> ObterAlmoxarifado(string codigoAreaMrp, string codigoCentroMrp)
        {
            var almoxarifado = await Db.Almoxarifados
                .Where(p => codigoAreaMrp.Equals(p.CodigoAreaMrp) && codigoCentroMrp.Equals(p.CodigoCentroMrp)).Select(p => new Almoxarifado
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Codigo = p.Codigo,
                    CodigoAreaMrp = p.CodigoAreaMrp,
                    CodigoCentroMrp = p.CodigoCentroMrp
                })
                .FirstOrDefaultAsync();

            return almoxarifado;
        }

        public async Task<ISingleResult<Almoxarifado>> ExisteMesmoCodigoCentroMrp(int id, string codigoCentroMrp)
        {
            var existe = await Db.Almoxarifados
                .Where(p => p.Id != id
                            && codigoCentroMrp.Equals(p.CodigoCentroMrp))
                .AnyAsync();

            return existe ? new SingleResult<Almoxarifado>(MensagensNegocio.MSG08) : new SingleResult<Almoxarifado>();
        }

        public async Task<ISingleResult<Almoxarifado>> ExisteAssociacoes(int id)
        {
            var existe = await Db.UepAlmoxarifados
                .Where(p => p.AlmoxarifadoId == id)
                .AnyAsync();

            return existe ? new SingleResult<Almoxarifado>(MensagensNegocio.MSG09) : new SingleResult<Almoxarifado>();
        }
    }
}