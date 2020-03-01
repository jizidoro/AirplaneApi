using AirplaneProject.Application.Bases;
using AirplaneProject.Application.Dtos;
using System.Threading.Tasks;

namespace AirplaneProject.Application.Interfaces
{
	public interface IAirplaneAppService : IAppService
    {
		Task<IListResultDto<AirplaneDto>> Listar();
		Task<ISingleResultDto<AirplaneDto>> Obter(int id);
		Task<ISingleResultDto<EntityDto>> Incluir(AirplaneIncluirDto evento);
		Task<ISingleResultDto<EntityDto>> Editar(AirplaneEditarDto evento);
		Task<ISingleResultDto<EntityDto>> Excluir(AirplaneExcluirDto evento);
	}
}
