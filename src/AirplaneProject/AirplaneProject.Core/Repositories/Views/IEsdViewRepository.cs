using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Bases;
using AirplaneProject.Domain.Models.Views;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories.Views
{
	public interface IEsdViewRepository : IRepository<EsdView>
    {
		IQueryable<EsdView> ListarPorUnidade(string unidade, string ativo, string uep);

		IQueryable<EsdView> ListarPorPeriodo(string unidade, string ativo, string uep, int top, DateTime? dataInicial, DateTime? dataFinal, string texto, SortByDto orderBy);

		Task<EsdView> ObterEvento(int id);
	}
}
