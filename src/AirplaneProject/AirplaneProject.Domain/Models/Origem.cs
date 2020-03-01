using AirplaneProject.Domain.Attributes;
using AirplaneProject.Domain.Bases;
using AirplaneProject.Domain.Interfaces;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Models
{
    [Entity(nameof(OrigemAgentes))]
    public class Origem : AutomacaoEntity
	{

		public IList<OrigemAgente> OrigemAgentes { get; set; }

		public override IEnumerable<IAssociacaoEntity> DadosAssociados => OrigemAgentes;

		public override string Include => "OrigemAgentes";
	}
}