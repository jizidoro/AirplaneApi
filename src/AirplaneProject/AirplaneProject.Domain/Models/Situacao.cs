using System.Collections.Generic;
using AirplaneProject.Domain.Bases;
using AirplaneProject.Domain.Interfaces;

namespace AirplaneProject.Domain.Models
{
	public class Situacao : BaseAutomacaoEntity
	{
		public IEnumerable<Alteracao> Alteracoes { get; set; }
		public IList<HistoricoAlteracao> HistoricoAlteracoes { get; set; }

		public IList<Esd> Esds { get; set; }
		public IList<Historico> Historicos { get; set; }

        public const string CodigoPadrao = "em analise";
    }
}