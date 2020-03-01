using System.Collections.Generic;
using AirplaneProject.Domain.Bases;

namespace AirplaneProject.Domain.Models
{
    public class SituacaoMaterial : BaseAutomacaoEntity
    {
        public string Cor { get; set; }
        public IEnumerable<MaterialEstocado> MaterialEstocados { get; set; }
    }
}