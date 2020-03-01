using AirplaneProject.Domain.Bases;
using System;

namespace AirplaneProject.Domain.Models.Views
{
	public class EsdView : Entity
	{
		public DateTime DataEvento { get; set; }
		public int UnidadeId { get; set; }
		public string UnidadeCodigo { get; set; }
		public string UnidadeNome { get; set; }
		public int AtivoId { get; set; }
		public string AtivoCodigo { get; set; }
		public string AtivoNome { get; set; }		
		public int UepId { get; set; }
		public string UepCodigo { get; set; }
		public string UepNome { get; set; }
		public int EventoIniciadorId { get; set; }
		public int EventoId { get; set; }
		public string EventoNome { get; set; }
		public string EventoCodigo { get; set; }
		public int IniciadorId { get; set; }
		public string IniciadorNome { get; set; }
		public string IniciadorCodigo { get; set; }
		public int NivelOperacaoId { get; set; }
		public int NivelId { get; set; }
		public string NivelNome { get; set; }
		public string NivelCodigo { get; set; }
		public int MotivoCausaId { get; set; }
		public int MotivoId { get; set; }
		public string MotivoNome { get; set; }
		public string MotivoCodigo { get; set; }
		public string SituacaoCodigo { get; set; }
		public string SituacaoNome { get; set; }
		public int SituacaoId { get; set; }
		public int CausaId { get; set; }
		public string CausaNome { get; set; }
		public string CausaCodigo { get; set; }
		public int OrigemAgenteId { get; set; }
		public int OrigemId { get; set; }
		public string OrigemNome { get; set; }
		public string OrigemCodigo { get; set; }
		public int AgenteId { get; set; }
		public string AgenteNome { get; set; }
		public string AgenteCodigo { get; set; }
		public string Descricao { get; set; }
		public string DescricaoCodigo { get; set; }
		public string LinkSitop { get; set; }
		public string LinkCadinc { get; set; }
		public string LinkGip { get; set; }
		public string LinkRta { get; set; }
		public string Alarme { get; set; }
		public string AlarmeCodigo { get; set; }
	}
}
