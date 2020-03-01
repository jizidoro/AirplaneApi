using System;
using System.Collections.Generic;
using System.Text;

namespace AirplaneProject.Core.Models.Dtos
{
	public class EsdListaEncadeadaPorDataDto
	{
		public DateTime? DataAnterior { get; set; }
		public DateTime? DataAtual { get; set; }
		public int DiasSemEsd
		{ 
			get 
			{
				var diasSemEsd = 0;
				if (!DataAtual.HasValue)
				{
					DataAtual = DateTime.Now;	
				}

				if (DataAnterior.HasValue && DataAtual.HasValue)
				{
					diasSemEsd = (int)DataAtual.Value.Subtract(DataAnterior.Value).TotalDays;
				}

				return diasSemEsd;
			}
			
		}
	}
}
