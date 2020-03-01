using System.Collections.Generic;
using AirplaneProject.Domain.Bases;

namespace AirplaneProject.Domain.Models
{
    public class EventoIniciador : AssociacaoEntity
	{   
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
		public int IniciadorId { get; set; }
		public Iniciador Iniciador { get; set; }
		
		public override string Value
		{
			get
			{
				if (this.Iniciador != null)
				{
					return this.Iniciador.Nome;
				}
				else if (this.Evento != null)
				{
					return this.Evento.Nome;
				}
				else
				{
					return this.ToString();
				}
			} 
		}
		public override int ParentKey => this.EventoId;
	}
}