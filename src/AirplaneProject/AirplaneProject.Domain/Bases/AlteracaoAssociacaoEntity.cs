using AirplaneProject.Domain.Interfaces;
using AirplaneProject.Domain.Models;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Bases
{
	public class AlteracaoAssociacaoEntity : Entity
	{
		public IList<Alteracao> Alteracoes { get; set; }
        public IList<HistoricoAlteracao> HistoricoAlteracoes { get; set; }
    }
}
