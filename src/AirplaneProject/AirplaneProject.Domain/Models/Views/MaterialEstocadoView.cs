using AirplaneProject.Domain.Bases;
using System;

namespace AirplaneProject.Domain.Models.Views
{
    public class MaterialEstocadoView : Entity
    {

        public int AlmoxarifadoId { get; set; }
        public string AlmoxarifadoCodigo { get; set; }
        public string AlmoxarifadoNome { get; set; }

        public int SituacaoMaterialId { get; set; }
        public string SituacaoMaterialCodigo { get; set; }
        public string SituacaoMaterialNome { get; set; }       
        public int CategoriaMaterialId { get; set; }
        public string CategoriaMaterialCodigo { get; set; }
        public string CategoriaMaterialNome { get; set; }

        public int ClasseMaterialId { get; set; }
        public string ClasseMaterialCodigo { get; set; }
        public string ClasseMaterialNome { get; set; }

        public int FabricanteId { get; set; }
        public string FabricanteCodigo { get; set; }
        public string FabricanteNome { get; set; }

        public int MrpId { get; set; }
        public string MrpCodigo { get; set; }
        public string MrpNome { get; set; }

        public int MaterialFornecidoId { get; set; }
        public string MaterialFornecidoCodigo { get; set; }
        public string MaterialFornecidoNM { get; set; }
        public string MaterialFornecidoPartNumber { get; set; }

        public string DescricaoCodigo { get; set; }
    }
}
