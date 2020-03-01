using AirplaneProject.Domain.Bases;
using System;

namespace AirplaneProject.Domain.Models
{
	public class MaterialEstocado : Entity
    {
		public int AlmoxarifadoId { get; set; }
		public Almoxarifado Almoxarifado { get; set; }

		public int MaterialFornecidoId { get; set; }
		public MaterialFornecido MaterialFornecido { get; set; }

		public int SituacaoMaterialId { get; set; }
		public SituacaoMaterial SituacaoMaterial { get; set; }

		public int MrpId { get; set; }
		public Mrp Mrp { get; set; }

		public double Maximo { get; set; }
		public double Minimo { get; set; }
		public double QuantidadeEstoque { get; set; }

		public DateTime DataRegistro { get; set; }
	}
}
