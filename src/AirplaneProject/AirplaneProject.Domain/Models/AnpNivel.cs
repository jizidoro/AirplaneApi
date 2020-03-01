using AirplaneProject.Domain.Bases;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Models
{
	public class AnpNivel : Entity
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public IList<Nivel> Niveis { get; set; }

		public override string Value => this.Nome;
	}
}