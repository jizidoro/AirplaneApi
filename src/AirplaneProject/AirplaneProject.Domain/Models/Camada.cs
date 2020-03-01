using System.Collections.Generic;
using AirplaneProject.Domain.Bases;
using AirplaneProject.Domain.Interfaces;

namespace AirplaneProject.Domain.Models
{
	public class Camada : BaseAutomacaoEntity
	{
		public IList<Alteracao> Alteracoes { get; set; }
		public IList<HistoricoAlteracao> HistoricoAlteracoes { get; set; }

        public const string CodigoPadrao = "controle";
    }
}