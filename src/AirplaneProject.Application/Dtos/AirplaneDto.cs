using AirplaneProject.Application.Bases;
using System;

namespace AirplaneProject.Application.Dtos
{
	public class AirplaneDto : EntityDto
	{
		public string Codigo { get; set; }
		public string Modelo { get; set; }
		public int QuantidadePassageiros { get; set; }
		public DateTime DataRegistro { get; set; }
	}
}
