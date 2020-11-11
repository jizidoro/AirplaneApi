using System.Linq;
using System.Threading.Tasks;
using AirplaneProject.Application.Bases;
using AirplaneProject.Application.Dtos;
using AirplaneProject.Application.Interfaces;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Core.Usecases.AirplaneUsecase;
using AirplaneProject.Domain.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace AirplaneProject.Application.Services
{
	 public class AirplaneAppService : AppService, IAirplaneAppService
	 {
		  private readonly IAirplaneRepository _repository;
		  private readonly EditarAirplaneUsecase _editarAirplaneUsecase;
		  private readonly IncluirAirplaneUsecase _incluirAirplaneUsecase;
		  private readonly ExcluirAirplaneUsecase _excluirAirplaneUsecase;

		  public AirplaneAppService(IAirplaneRepository repository,
			  EditarAirplaneUsecase editarAirplaneUsecase,
			  IncluirAirplaneUsecase incluirAirplaneUsecase,
			  ExcluirAirplaneUsecase excluirAirplaneUsecase,
			  IMapper mapper)
			  : base(mapper)
		  {
			   this._repository = repository;
			   this._editarAirplaneUsecase = editarAirplaneUsecase;
			   this._incluirAirplaneUsecase = incluirAirplaneUsecase;
			   this._excluirAirplaneUsecase = excluirAirplaneUsecase;
		  }

		  public async Task<IListResultDto<AirplaneDto>> Listar()
		  {
			   var lista = await Task.Run(() => _repository.GetAll()
				   .ProjectTo<AirplaneDto>(Mapper.ConfigurationProvider)
				   .ToList());

			   return new ListResultDto<AirplaneDto>(lista);
		  }

		  public async Task<ISingleResultDto<AirplaneDto>> Obter(int id)
		  {
			   var entity = await _repository.GetById(id);
			   var dto = Mapper.Map<AirplaneDto>(entity);
			   return new SingleResultDto<AirplaneDto>(dto);
		  }

		  public async Task<ISingleResultDto<EntityDto>> Incluir(AirplaneIncluirDto dto)
		  {
			   var evento = Mapper.Map<Airplane>(dto);

			   var result = await _incluirAirplaneUsecase.Execute(evento);

			   var resultDto = new SingleResultDto<EntityDto>(result);
			   resultDto.SetData(result, Mapper);

			   return resultDto;
		  }

		  public async Task<ISingleResultDto<EntityDto>> Editar(AirplaneEditarDto dto)
		  {
			   var evento = Mapper.Map<Airplane>(dto);

			   var result = await _editarAirplaneUsecase.Execute(evento);

			   var resultDto = new SingleResultDto<EntityDto>(result);
			   resultDto.SetData(result, Mapper);

			   return resultDto;
		  }

		  public async Task<ISingleResultDto<EntityDto>> Excluir(int id)
		  {
			   var result = await _excluirAirplaneUsecase.Execute(id);

			   var resultDto = new SingleResultDto<EntityDto>(result);
			   resultDto.SetData(result, Mapper);

			   return resultDto;
		  }
	 }
}
