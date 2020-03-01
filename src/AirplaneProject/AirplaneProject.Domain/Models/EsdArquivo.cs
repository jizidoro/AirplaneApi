using AirplaneProject.Domain.Bases;

namespace AirplaneProject.Domain.Models
{
    public class EsdArquivo : Entity
    {        
        public Esd Esd { get; set; }
        public int EsdId { get; set; }
        public string NomeArquivo { get; set; }
        public string Url { get; set; }
    }
}