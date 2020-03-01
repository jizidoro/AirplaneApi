using AirplaneProject.Domain.Models;
using AirplaneProject.Core.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IEsdService
	{
		Task<ISingleResult<Esd>> Incluir(Esd evento);

		Task<ISingleResult<Esd>> Editar(Esd evento);

		Task<ISingleResult<Esd>> Excluir(int id);

		int CalcularDiasSemEsd(Esd ultimoEvento);

		int CalcularRecorde(IList<EsdListaEncadeadaPorDataDto> lista, Esd ultimoEvento);
	}
}
