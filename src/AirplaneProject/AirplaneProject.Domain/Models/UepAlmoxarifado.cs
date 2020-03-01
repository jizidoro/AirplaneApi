using System.Collections.Generic;
using AirplaneProject.Domain.Bases;

namespace AirplaneProject.Domain.Models
{
    public class UepAlmoxarifado : AssociacaoEntity
	{   
        public int UepId { get; set; }
        public Uep Uep { get; set; }
		public int AlmoxarifadoId { get; set; }
		public Almoxarifado Almoxarifado { get; set; }

		public override string Value
		{
			get
			{
				if (this.Almoxarifado != null)
				{
					return this.Almoxarifado.Nome;
				}
				else if (this.Uep != null)
				{
					return this.Uep.Nome;
				}
				else
				{
					return this.ToString();
				}
			}
		}
		public override int ParentKey => this.UepId;
	}
}