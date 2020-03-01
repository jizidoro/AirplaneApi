using AirplaneProject.Domain.Models;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Interfaces
{
	public interface IAssociacaoEntity : IEntity
	{
		IList<Esd> Esds { get; set; }
	}
}
