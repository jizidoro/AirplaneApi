using System.Threading.Tasks;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;

namespace AirplaneProject.Core.Repositories
{
	public interface IAtivoRepository : IRepository<Ativo>
	{
		Ativo ObterPorNome(string ativo);
	}
}
