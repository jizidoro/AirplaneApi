using System.Collections.Generic;
using AirplaneProject.Domain.Bases;

namespace AirplaneProject.Domain.Models
{
	public class Profissional : Entity
	{
		public string Chave { get; set; }
		public string Nome { get; set; }

		public override string Value => Chave.ToUpper() + " - " + Nome;
	}
}