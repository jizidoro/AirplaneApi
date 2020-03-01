using System.Collections.Generic;
using AirplaneProject.Domain.Bases;

namespace AirplaneProject.Domain.Models
{
	public class Funcao : BaseAutomacaoEntity
	{
		public IList<Alteracao> Alteracoes { get; set; }

		public IList<HistoricoAlteracao> HistoricoAlteracoes { get; set; }

        public const string CodigoPadrao = "nao identificado";
    }
}