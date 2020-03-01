using AirplaneProject.Domain.Attributes;
using AirplaneProject.Domain.Bases;
using AirplaneProject.Domain.Interfaces;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Models
{
    [Entity(nameof(MotivoCausas))]
    public class Motivo : AutomacaoEntity
	{
		public IList<MotivoCausa> MotivoCausas { get; set; }

		public override IEnumerable<IAssociacaoEntity> DadosAssociados => MotivoCausas;

		public override string Include => "MotivoCausas";
	}
}