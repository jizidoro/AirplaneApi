using AirplaneProject.Domain.Attributes;
using AirplaneProject.Domain.Bases;
using AirplaneProject.Domain.Interfaces;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Models
{
    [Entity(nameof(EventoIniciadores))]
    public class Evento : AutomacaoEntity
	{
		public IList<EventoIniciador> EventoIniciadores { get; set; }

		public override IEnumerable<IAssociacaoEntity> DadosAssociados => EventoIniciadores;

		public override string Include => "EventoIniciadores";
	}
}