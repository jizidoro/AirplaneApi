using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IAlmoxarifadoService
	{
		Task<ISingleResult<Almoxarifado>> Incluir(Almoxarifado entity);

		Task<ISingleResult<Almoxarifado>> Editar(Almoxarifado entity);

		Task<ISingleResult<Almoxarifado>> Excluir(int id);
	}
}
