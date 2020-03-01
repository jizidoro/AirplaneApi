using System;
using System.Linq;
using System.Threading.Tasks;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Domain.Bases;
using AirplaneProject.Domain.Models;

namespace AirplaneProject.Core.Repositories
{
	public interface IAlteracaoRepository : IRepository<Alteracao>
    {
	    IQueryable<Alteracao> ListarPorUnidade(string unidade, string ativo, string uep);

	    Task<Alteracao> ObterAlteracao(int id);

	    Task<bool> ExisteEventoParaUnidadeDataHora(int id, int uepId, DateTime dataEvento);
	    Task<bool> ExisteEventoParaUnidadeChecksum(int id, int uepId, string checksum);

	    Task<Alteracao> ObterUltimoEvento(string unidade, string ativo, string uep);
	}
}
