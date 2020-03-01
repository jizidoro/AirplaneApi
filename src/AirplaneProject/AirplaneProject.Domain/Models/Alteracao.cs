using System;
using System.Collections.Generic;
using AirplaneProject.Domain.Bases;

namespace AirplaneProject.Domain.Models
{
	public class Alteracao : Entity
	{
		public Uep Uep { get; set; }
		public int UepId { get; set; }
		public Finalidade Finalidade { get; set; }
		public int FinalidadeId { get; set; }
		public Camada Camada { get; set; }
		public int CamadaId { get; set; }
		public Funcao Funcao { get; set; }
		public int FuncaoId { get; set; }
		public Sistema Sistema { get; set; }
		public int SistemaId { get; set; }
		public Situacao Situacao { get; set; }
		public int SituacaoId { get; set; }
		public Profissional Solicitante { get; set; }
		public int SolicitanteId { get; set; }
		public Profissional Executor { get; set; }
		public int? ExecutorId { get; set; }
		public Profissional Aprovador { get; set; }
		public int? AprovadorId { get; set; }
		public Profissional Autorizador { get; set; }
		public int? AutorizadorId { get; set; }
		public Profissional Verificador { get; set; }
		public int? VerificadorId { get; set; }

		public IList<HistoricoAlteracao> HistoricoAlteracoes { get; set; }

		public string Checksum { get; set; }
		public DateTime DataEvento { get; set; }
		public DateTime DataRegistro { get; set; }
		public string Descricao { get; set; }
		public string DescricaoCodigo { get; set; }
		
		public string ChaveUsuario { get; set; }
		public string NomeUsuario { get; set; }
	}
}