using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class MaterialFornecidoRepository : Repository<MaterialFornecido>, IMaterialFornecidoRepository
	{
		public MaterialFornecidoRepository(GestaoEsdContext context)
			: base(context)
		{			
		}

        public async Task<MaterialFornecido> ObterPorCodigoSap(string codigoConsultaSap)
        {
            var MaterialFornecido = await Db.MaterialFornecidos
                .Where(p => codigoConsultaSap.Equals(p.NM)).Select(p => new MaterialFornecido
                {
                    Id = p.Id,
                    ClasseMaterialId = p.ClasseMaterialId,
                    FabricanteId = p.FabricanteId,
                    Codigo = p.Codigo,
                    NM = p.NM,
                    PartNumber = p.PartNumber,
                    Modelo = p.Modelo
                })
                .FirstOrDefaultAsync();

            return MaterialFornecido;
        }

        public async Task<bool> ExisteMaterialFornecidoComMesmoNM(string NM, int id = 0)
        {
            bool existe;

            if (id == 0)
            {
                existe = Db.MaterialFornecidos
                    .Where(p => NM.Equals(p.NM))
                    .Any();
            }
            else
            {
                existe = await Db.MaterialFornecidos
                    .Where(p => NM.Equals(p.NM) && !p.Id.Equals(id))
                    .AnyAsync();
            }

            return existe;
        }

        public async Task<bool> ExisteMaterialFornecidoComMesmoCodigo(string codigo, int id = 0)
        {
            bool existe;

            if (id == 0)
            {
                existe = await Db.MaterialFornecidos
                .Where(p => p.Codigo.Equals(codigo))
                .AnyAsync();
            }
            else
            {
                existe = await Db.MaterialFornecidos
                .Where(p => p.Codigo.Equals(codigo) && !p.Id.Equals(id))
                .AnyAsync();
            }

            return existe;
        }

        public async Task<bool> PossuiMateriaisEstocados(int id)
        {
            var possui = await Db.MaterialEstocados.AnyAsync(x=> x.MaterialFornecidoId == id);

            return possui;
        }

        public async Task<MaterialFornecido> ObterMaterialFornecido(int id)
        {
            var evento = await Db.MaterialFornecidos
                .Where(p => p.Id == id)
                .Select(p => new MaterialFornecido
                {
                    Id = p.Id,
                    NM = p.NM,
                    Fabricante = new Fabricante()
                    {
                        Id = p.Fabricante.Id,
                        Nome = p.Fabricante.Nome,
                        Descricao = p.Fabricante.Descricao,
                        CodigoSAP = p.Fabricante.CodigoSAP,
                        Codigo = p.Fabricante.Codigo
                    },
                    ClasseMaterial = new ClasseMaterial()
                    {
                        Id = p.ClasseMaterial.Id,
                        CategoriaMaterial = p.ClasseMaterial.CategoriaMaterial,
                        Codigo = p.ClasseMaterial.Codigo,
                        Descricao = p.ClasseMaterial.Descricao,
                        Nome = p.ClasseMaterial.Nome,
                        CategoriaMaterialId = p.ClasseMaterial.CategoriaMaterial.Id
                    },
                    Codigo =p.Codigo,
                    PartNumber = p.PartNumber,
                    Modelo = p.Modelo
                })
                .FirstOrDefaultAsync();

            return evento;
        }


        public async Task<MaterialFornecido> ObterMaterialFornecido(string NM)
        {
            var evento = await Db.MaterialFornecidos
                .Where(p => NM.Equals(p.NM))
                .Select(p => new MaterialFornecido
                {
                    Id = p.Id,
                    NM = p.NM,
                    Fabricante = new Fabricante()
                    {
                        Id = p.Fabricante.Id,
                        Nome = p.Fabricante.Nome,
                        Descricao = p.Fabricante.Descricao,
                        CodigoSAP = p.Fabricante.CodigoSAP,
                        Codigo = p.Fabricante.Codigo
                    },
                    ClasseMaterial = new ClasseMaterial()
                    {
                        Id = p.ClasseMaterial.Id,
                        Codigo = p.ClasseMaterial.Codigo,
                        Descricao = p.ClasseMaterial.Descricao,
                        Nome = p.ClasseMaterial.Nome,
                        CategoriaMaterial = p.ClasseMaterial.CategoriaMaterial,
                        CategoriaMaterialId = p.ClasseMaterial.CategoriaMaterial.Id
                    },
                    Codigo = p.Codigo,
                    PartNumber = p.PartNumber,
                    Modelo = p.Modelo
                })
                .FirstOrDefaultAsync();

            return evento;
        }
    }
}