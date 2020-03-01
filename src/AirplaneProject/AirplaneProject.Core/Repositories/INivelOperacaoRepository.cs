using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Repositories
{
	public interface INivelOperacaoRepository : IRepository<NivelOperacao>
    {
		Task<NivelOperacao> ObterPorNivelUep(string nivelNome, Uep uep);
	}
}
