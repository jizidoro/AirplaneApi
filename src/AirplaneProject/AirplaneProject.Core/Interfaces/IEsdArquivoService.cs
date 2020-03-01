using AirplaneProject.Domain.Models;
using AirplaneProject.Core.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Interfaces
{
	public interface IEsdArquivoService
	{
		Task<ISingleResult<EsdArquivo>> Incluir(EsdArquivo evento);

		Task<ISingleResult<EsdArquivo>> Excluir(int id);
	}
}
