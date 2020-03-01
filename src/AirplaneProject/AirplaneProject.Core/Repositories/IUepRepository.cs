using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;

namespace AirplaneProject.Core.Repositories
{
	public interface IUepRepository : IRepository<Uep>
	{
		Uep ObterPorNome(string uep);
	}
}
