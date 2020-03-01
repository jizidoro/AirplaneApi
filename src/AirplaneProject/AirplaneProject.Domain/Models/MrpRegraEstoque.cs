using AirplaneProject.Domain.Bases;
using AirplaneProject.Domain.Enums;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Models
{
	public class MrpRegraEstoque : Entity
    {
		public EnumCampoMaterialEstocado Campo { get; set; }
		public EnumSituacaoRegraEstoque SituacaoRegraEstoque { get; set; }
		public EnumOperador Operador { get; set; }
		public double Quantidade { get; set; }

		public IEnumerable<Mrp> Mrps { get; set; }

		public int MrpId { get; set; }
		public Mrp Mrp { get; set; }
	}
}
