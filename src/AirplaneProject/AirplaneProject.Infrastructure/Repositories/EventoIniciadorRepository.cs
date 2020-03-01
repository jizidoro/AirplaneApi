using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AirplaneProject.Core.Extensions;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class EventoIniciadorRepository : Repository<EventoIniciador>, IEventoIniciadorRepository
	{
		public EventoIniciadorRepository(GestaoEsdContext context)
			: base(context)
		{
			
		}

		public async Task<EventoIniciador> ObterPorEventoIniciadorNome(string eventoNome, string iniciadorNome)
		{
			if (string.IsNullOrEmpty(eventoNome))
			{
				return null;
			}

			if (string.IsNullOrEmpty(iniciadorNome))
			{
				return null;
			}

			var eventoCodigo = eventoNome.RemoveDiacritics().ToLower();
			var iniciadorCodigo = iniciadorNome.RemoveDiacritics().ToLower();

			var x = await Db.EventoIniciadores					
					.Where(p =>
						p.Evento.Codigo == eventoCodigo &&
						p.Iniciador.Codigo == iniciadorCodigo
					)
					.FirstOrDefaultAsync();

			return x;
		}
	}
}