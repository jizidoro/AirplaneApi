using AirplaneProject.Application.Bases;
using AirplaneProject.Application.Dtos;
using System.Threading.Tasks;

namespace AirplaneProject.Application.Interfaces
{
	public interface IAirplaneAppService : IAppService
    {
		Task<IListResultDto<AirplaneDto>> Listar();
		Task<ISingleResultDto<AirplaneDto>> Obter(int id);
		Task<ISingleResultDto<EntityDto>> Incluir(AirplaneIncluirDto dto);
		Task<ISingleResultDto<EntityDto>> Editar(AirplaneEditarDto dto);
		Task<ISingleResultDto<EntityDto>> Excluir(int id);
	}
}
