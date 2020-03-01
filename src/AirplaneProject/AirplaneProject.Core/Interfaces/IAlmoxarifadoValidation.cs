using AirplaneProject.Domain.Models;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IAlmoxarifadoValidation
	{
		Task<ISingleResult<Almoxarifado>> ValidarInclusao(Almoxarifado entity);

		Task<ISingleResult<Almoxarifado>> ValidarEdicao(Almoxarifado entity);

		Task<ISingleResult<Almoxarifado>> ValidarExclusao(int id);
	}
}
