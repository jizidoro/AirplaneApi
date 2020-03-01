using AirplaneProject.Domain.Bases;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Models
{
	public class Ativo : Entity
    {
		public int UnidadeOperativaId { get; set; }
		public UnidadeOperativa UnidadeOperativa { get; set; }
		public string Nome { get; set; }
		public string Codigo { get; set; }
		public string Descricao { get; set; }
		public IEnumerable<Uep> Ueps { get; set; }

		public override string Value => this.Nome;
		public override int ParentKey => this.UnidadeOperativaId;
	}
}
