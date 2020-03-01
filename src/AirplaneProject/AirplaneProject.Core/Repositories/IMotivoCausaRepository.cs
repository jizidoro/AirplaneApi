using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories
{
	public interface IMotivoCausaRepository : IRepository<MotivoCausa>
    {
		Task<MotivoCausa> ObterPorMotivoCausaNome(string motivoNome, string causaNome);
	}
}
