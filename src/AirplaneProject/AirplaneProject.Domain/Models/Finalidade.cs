
using System.Collections.Generic;
using AirplaneProject.Domain.Bases;

namespace AirplaneProject.Domain.Models
{
	public class Finalidade : BaseAutomacaoEntity
	{
		public IList<Alteracao> Alteracoes { get; set; }
		public IList<HistoricoAlteracao> HistoricoAlteracoes { get; set; }

        public const string CodigoPadrao = "melhoria";
    }
}