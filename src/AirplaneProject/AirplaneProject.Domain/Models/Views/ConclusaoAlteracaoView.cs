using AirplaneProject.Domain.Bases;
using System;

namespace AirplaneProject.Domain.Models.Views
{
	public class ConclusaoAlteracaoView : Entity
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
		public string SituacaoCodigo { get; set; }
		public string SituacaoNome { get; set; }
		public int SituacaoId { get; set; }
		
	}
}
