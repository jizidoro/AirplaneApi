using AirplaneProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AirplaneProject.Domain.Bases
{
	public abstract class AutomacaoEntity : Entity
    {		
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public string Codigo { get; set; }

		public override string Value => Nome;

		public virtual IEnumerable<IAssociacaoEntity>  DadosAssociados { get; set; }

		public virtual string Include { get; set; }
	}
}
