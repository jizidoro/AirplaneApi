using System.Collections.Generic;

namespace AirplaneProject.Domain.Models
{
	public class Acesso
    {
        public List<Uep> ListaUep { get; set; }

        public void CriarAcesso(List<Uep> _ListaUep)
        {
            ListaUep = _ListaUep;
        }
    }
}