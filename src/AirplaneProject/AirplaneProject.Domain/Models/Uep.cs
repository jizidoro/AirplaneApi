using AirplaneProject.Domain.Bases;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Models
{
	public class Uep : Entity
	{
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
		public int AtivoId { get; set; }
		public Ativo Ativo { get; set; }
		public int UepTipoId { get; set; }
        public UepTipo UepTipo { get; set; }
		public int OperacaoId { get; set; }
		public Operacao Operacao { get; set; }

		public IEnumerable<Esd> Esds { get; set; }

		public override string Value => this.Nome;
		public override int ParentKey => this.AtivoId;

		public IList<UepAlmoxarifado> UepAlmoxarifados { get; set; }
	}
}