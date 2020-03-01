using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Bases;
using AirplaneProject.Domain.Models.Views;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories.Views
{
	public interface IConclusaoAlteracaoViewRepository : IRepository<ConclusaoAlteracaoView>
    {
		IQueryable<ConclusaoAlteracaoView> ListarPorUnidade(string unidade, string ativo, string uep);
		IQueryable<ConclusaoAlteracaoView> ObterGridConclusao(string unidade, string ativo, string uep, DateTime? dataInicial, DateTime? dataFinal);
	}
}
