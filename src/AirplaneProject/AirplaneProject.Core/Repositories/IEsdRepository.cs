using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Bases;
using AirplaneProject.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories
{
	public interface IEsdRepository : IRepository<Esd>
    {
		IQueryable<Esd> ListarPorUnidade(string unidade, string ativo, string uep);

		IQueryable<Esd> ListarPorPeriodo(string unidade, string ativo, string uep, int top, DateTime? dataInicial, DateTime? dataFinal, string texto, SortByDto orderBy);

		Task<Esd> ObterEvento(int id);

		Task<bool> ExisteEventoParaUnidadeDataHora(int id, int uepId, DateTime dataEvento);

		Task<Esd> ObterUltimoEvento(string unidade, string ativo, string uep);
	}
}
