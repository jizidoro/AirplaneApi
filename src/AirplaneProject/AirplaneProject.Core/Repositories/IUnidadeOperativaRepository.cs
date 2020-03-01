using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using System.Linq;

namespace AirplaneProject.Core.Repositories
{
	public interface IUnidadeOperativaRepository : IRepository<UnidadeOperativa>
    {
		IQueryable<UnidadeOperativa> ListarArvoreElementos();
	}
}
