using AirplaneProject.Domain.Bases;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Models
{
	public class CategoriaMaterial : BaseAutomacaoEntity
	{
		public IEnumerable<ClasseMaterial> ClasseMateriais { get; set; }
	}
}
