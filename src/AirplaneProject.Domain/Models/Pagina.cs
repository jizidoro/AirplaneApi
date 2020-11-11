using AirplaneProject.Domain.Bases;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirplaneProject.Domain.Models
{
	public class Pagina : Book
	{

		public short NumeroPagina { get; set; }
	}
}
