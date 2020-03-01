using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories
{
	public interface IEventoIniciadorRepository : IRepository<EventoIniciador>
    {
		Task<EventoIniciador> ObterPorEventoIniciadorNome(string eventoNome, string iniciadorNome);
	}
}
