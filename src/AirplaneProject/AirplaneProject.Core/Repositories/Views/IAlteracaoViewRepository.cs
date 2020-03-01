using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Bases;
using AirplaneProject.Domain.Models.Views;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories.Views
{
    public interface IAlteracaoViewRepository : IRepository<AlteracaoView>
    {
		IQueryable<AlteracaoView> ListarPorUnidade(string unidade, string ativo, string uep);

		IQueryable<AlteracaoView> ListarPorPeriodo(string unidade, string ativo, string uep, int top, DateTime? dataInicial, DateTime? dataFinal, string texto, SortByDto orderBy);

		IQueryable<AlteracaoView> ObterGridConclusao(string unidade, string ativo, string uep, DateTime? dataInicial, DateTime? dataFinal);

		Task<AlteracaoView> ObterEvento(int id);
	}
}
