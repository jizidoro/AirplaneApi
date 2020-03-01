using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AirplaneProject.Domain.Queries;
using System.Linq.Expressions;
using System;

namespace AirplaneProject.Infrastructure.Repositories
{
    public class MaterialEstocadoRepository : Repository<MaterialEstocado>, IMaterialEstocadoRepository
    {
        public MaterialEstocadoRepository(GestaoEsdContext context)
            : base(context)
        {
        }

        public async Task<MaterialEstocado> ObterMaterialEstocado(int id)
        {
            var evento = await Db.MaterialEstocados
                .Where(p => p.Id == id)
                .Select(p => new MaterialEstocado
                {
                    Id = p.Id,
                    Maximo = p.Maximo,
                    Minimo = p.Minimo,
                    QuantidadeEstoque = p.QuantidadeEstoque,
                    Almoxarifado = new Almoxarifado()
                    {
                        Nome = p.Almoxarifado.Nome,
                        Descricao = p.Almoxarifado.Descricao,
                        CodigoCentroMrp = p.Almoxarifado.CodigoCentroMrp,
                        CodigoAreaMrp = p.Almoxarifado.CodigoAreaMrp,
                        Codigo = p.Almoxarifado.Codigo,
                        Id = p.Almoxarifado.Id
                    },
                    AlmoxarifadoId = p.AlmoxarifadoId,
                    MaterialFornecido = new MaterialFornecido()
                    {
                        Id = p.MaterialFornecido.Id,
                        NM = p.MaterialFornecido.NM
                    },
                    MaterialFornecidoId = p.MaterialFornecidoId,
                    SituacaoMaterial = new SituacaoMaterial()
                    {
                        Id = p.SituacaoMaterial.Id
                    },
                    SituacaoMaterialId = p.SituacaoMaterialId,
                    Mrp = new Mrp()
                    {
                        Id = p.Mrp.Id
                    },
                    MrpId = p.MrpId,
                })
                .FirstOrDefaultAsync();

            return evento;
        }

        public async Task<MaterialEstocado> ObterMaterialEstocado(int almoxarifadoId, int materialFornecidoId, int mrpId)
        {
            var evento = await Db.MaterialEstocados
                .Where(p => p.AlmoxarifadoId == almoxarifadoId && p.MaterialFornecidoId == materialFornecidoId && p.MrpId == mrpId)
                .Select(p => new MaterialEstocado
                {
                    Id = p.Id,
                    Maximo = p.Maximo,
                    Minimo = p.Minimo,
                    QuantidadeEstoque = p.QuantidadeEstoque,
                    AlmoxarifadoId = p.AlmoxarifadoId,
                    MaterialFornecidoId = p.MaterialFornecidoId,
                    SituacaoMaterialId = p.SituacaoMaterialId,
                    MrpId = p.MrpId,
                })
                .FirstOrDefaultAsync();

            return evento;
        }

        public IEnumerable<MaterialEstocadoExportacaoQuery> ObterMaterialEstocado()
        {
            var result = DbSet.AsNoTracking()
                              .Select(x => new MaterialEstocadoExportacaoQuery
                              {
                                  AreaMrp = x.Almoxarifado.CodigoAreaMrp,
                                  CentroMrp = x.Almoxarifado.CodigoCentroMrp,
                                  Estoque = x.QuantidadeEstoque,
                                  Mrp = x.Mrp.Nome,
                                  NmMaterial = x.MaterialFornecido.NM,
                                  QtdMaxima = x.Maximo,
                                  QtdMinima = x.Minimo
                              });

            return result;
        }

        public Task<bool> CalculaMrpRegraEstoque(MaterialEstocado entity, Expression<Func<MaterialEstocado, bool>> predicate)
        {
            var query = new List<MaterialEstocado>() { entity };

            var allChild = query.AsQueryable()
                .Where(predicate).AnyAsync();

            return allChild;
        }
    }
}