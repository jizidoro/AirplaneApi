using AirplaneProject.Domain.Bases;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Models
{
	public class MaterialFornecido : Entity
    {
		public int ClasseMaterialId { get; set; }
		public ClasseMaterial ClasseMaterial { get; set; }

		public int FabricanteId { get; set; }
		public Fabricante Fabricante { get; set; }

		public string Codigo { get; set; }
		public string Nome { get; set; }
		public string NM { get; set; }
		
		public string PartNumber { get; set; }
		public string Modelo { get; set; }

		public IEnumerable<MaterialEstocado> MaterialEstocados { get; set; }

		public override string Value => this.NM;

	}
}
