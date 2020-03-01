using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Bases;
using AirplaneProject.Domain.Models.Views;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories.Views
{
	public interface ISobressalenteViewRepository : IRepository<SobressalenteView>
    {
		IQueryable<SobressalenteView> Listar(string unidade, string ativo, string uep, SortByDto orderBy);
	}
}
