using AirplaneProject.Domain.Bases;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Models
{
	public class Fabricante : Entity
    {
	    public string Nome { get; set; }
		public string Codigo { get; set; }
		public string CodigoSAP { get; set; }
		public string Descricao { get; set; }
		public IEnumerable<MaterialFornecido> MaterialFornecidos { get; set; }

		public override string Value => this.Nome;

	}
}
