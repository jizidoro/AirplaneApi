using AirplaneProject.Domain.Bases;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Models
{
	public class Mrp : Entity
    {
	    public string Nome { get; set; }
		public string Codigo { get; set; }
		public string Descricao { get; set; }

		public override string Value => this.Nome;

		public IEnumerable<MaterialEstocado> MaterialEstocados { get; set; }
		public IEnumerable<MrpRegraEstoque> MrpRegraEstoques { get; set; }
	}
}
