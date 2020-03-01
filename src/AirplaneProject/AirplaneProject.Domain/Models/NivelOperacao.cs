using AirplaneProject.Domain.Bases;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Models
{
	public class NivelOperacao : Entity
	{
        public int OperacaoId { get; set; }
        public Operacao Operacao { get; set; }
        public int NivelId { get; set; }
        public Nivel Nivel { get; set; }

		public IList<Esd> Esds { get; set; }
		public IList<Historico> Historicos { get; set; }

		public override string Value => this.Nivel.Nome;
		public override int ParentKey => this.OperacaoId;
	}
}