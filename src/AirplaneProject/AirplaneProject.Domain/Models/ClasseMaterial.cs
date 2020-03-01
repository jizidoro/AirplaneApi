using AirplaneProject.Domain.Bases;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Models
{
	public class ClasseMaterial : BaseAutomacaoEntity
	{
		public int CategoriaMaterialId { get; set; }
		public CategoriaMaterial CategoriaMaterial { get; set; }
		public IEnumerable<MaterialFornecido> MaterialFornecidos { get; set; }

	}
}
