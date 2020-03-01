using AirplaneProject.Domain.Bases;
using System;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Models
{
	public class Esd : Entity
	{
		public DateTime DataEvento { get; set; }
		public int UepId { get; set; }
		public Uep Uep { get; set; }
		public int NivelOperacaoId { get; set; }
		public NivelOperacao NivelOperacao { get; set; }
		public int SituacaoId { get; set; }
		public Situacao Situacao { get; set; }
		public int EventoIniciadorId { get; set; }
		public EventoIniciador EventoIniciador { get; set; }
		public int MotivoCausaId { get; set; }
		public MotivoCausa MotivoCausa { get; set; }
		public int OrigemAgenteId { get; set; }
		public OrigemAgente OrigemAgente { get; set; }
		public IList<Historico> Historicos { get; set; }
		public IList<EsdArquivo> Arquivos { get; set; }
		public string Descricao { get; set; }
		public string DescricaoCodigo { get; set; }
		public string LinkSitop { get; set; }
		public string LinkCadinc { get; set; }
		public string LinkGip { get; set; }
		public string LinkRta { get; set; }
		public string Alarme { get; set; }
		public string AlarmeCodigo { get; set; }
		public string ChaveUsuario { get; set; }
		public string NomeUsuario { get; set; }
		public DateTime DataRegistro { get; set; }

		public override string ToString()
		{
			return $"Esd: {this.Id}, {this.DataEvento}";
		}
	}
}