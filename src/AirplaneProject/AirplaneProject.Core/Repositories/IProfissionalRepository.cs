using System.Threading.Tasks;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;

namespace AirplaneProject.Core.Repositories
{
	public interface IProfissionalRepository : IRepository<Profissional>
	{
		Task<ISingleResult<Profissional>> ExisteMesmaChave(int id, string chave);

		Task<ISingleResult<Profissional>> ObterPorChave(string chave);
	}
}
