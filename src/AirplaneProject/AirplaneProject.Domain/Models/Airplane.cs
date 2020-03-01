using AirplaneProject.Domain.Bases;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Models
{
	public class Airplane : Entity
    {
		public string Codigo { get; set; }
		public string Modelo { get; set; }
		public int QuantidadePassageiros { get; set; }
		public Datetime DataRegistro { get; set; }

		public override string Value => this.Codigo;
	}
}
