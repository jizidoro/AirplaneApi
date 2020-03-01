using AirplaneProject.Domain.Bases;
using System;

namespace AirplaneProject.Domain.Models.Views
{
	public class AlteracaoView : Entity
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
		public string FinalidadeCodigo { get; set; }
		public string FinalidadeNome { get; set; }
		public int FinalidadeId { get; set; }
		public string CamadaCodigo { get; set; }
		public string CamadaNome { get; set; }
		public int CamadaId { get; set; }
		public string FuncaoCodigo { get; set; }
		public string FuncaoNome { get; set; }
		public int FuncaoId { get; set; }
		public string SistemaCodigo { get; set; }
		public string SistemaNome { get; set; }
		public int SistemaId { get; set; }
		public string SituacaoCodigo { get; set; }
		public string SituacaoNome { get; set; }
		public int SituacaoId { get; set; }
		public string SolicitanteChave { get; set; }
		public string SolicitanteNome { get; set; }
		public int SolicitanteId { get; set; }
		public string ExecutorChave { get; set; }
		public string ExecutorNome { get; set; }
		public int? ExecutorId { get; set; }
		public string AprovadorChave { get; set; }
		public string AprovadorNome { get; set; }
		public int? AprovadorId { get; set; }
		public string AutorizadorChave { get; set; }
		public string AutorizadorNome { get; set; }
		public int? AutorizadorId { get; set; }
		public string VerificadorChave { get; set; }
		public string VerificadorNome { get; set; }
		public int? VerificadorId { get; set; }
		public string Checksum{ get; set; }
		public string Descricao{ get; set; }
		public string DescricaoCodigo { get; set; }
	}
}
