using AirplaneProject.Domain.Interfaces;
using AirplaneProject.Domain.Models;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Bases
{
	public class AssociacaoEntity : Entity, IAssociacaoEntity
	{
		public IList<Esd> Esds { get; set; }
        public IList<Historico> Historicos { get; set; }
    }
}
