using AirplaneProject.Domain.Bases;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Models
{
	public class Nivel : Entity
	{
        public string Nome { get; set; }
		public string Codigo { get; set; }
		public string Descricao { get; set; }
		public int AnpNivelId { get; set; }
        public AnpNivel AnpNivel { get; set; }
        public IList<NivelOperacao> NivelOperacoes { get; set; }

		public override string Value => this.Nome;
	}
}