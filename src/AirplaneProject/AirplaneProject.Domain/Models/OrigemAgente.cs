using System.Collections.Generic;
using AirplaneProject.Domain.Bases;

namespace AirplaneProject.Domain.Models
{
    public class OrigemAgente : AssociacaoEntity
	{   
        public int OrigemId { get; set; }
        public Origem Origem { get; set; }
		public int AgenteId { get; set; }
		public Agente Agente { get; set; }

		public override string Value
		{
			get
			{
				if (this.Agente != null)
				{
					return this.Agente.Nome;
				}
				else if (this.Origem != null)
				{
					return this.Origem.Nome;
				}
				else
				{
					return this.ToString();
				}
			}
		}
		public override int ParentKey => this.OrigemId;
	}
}