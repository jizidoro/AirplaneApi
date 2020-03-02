using AirplaneProject.Application.Bases;
using AirplaneProject.Application.Dtos;
using AirplaneProject.Application.Interfaces;
using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Repositories;
using AirplaneProject.Domain.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneProject.Application.Services
{
	public class AirplaneAppService : AppService, IAirplaneAppService
	{
		private readonly IAirplaneRepository _repository;
		private readonly IAirplaneService _service;

		public AirplaneAppService(IAirplaneRepository _repository, IAirplaneService _service, IMapper _mapper)
			: base(_mapper)
		{
			this._repository = _repository;
			this._service = _service;
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

			var result = await _service.Incluir(evento);

			var resultDto = new SingleResultDto<EntityDto>(result);
			resultDto.SetData(result, Mapper);

			return resultDto;
		}

		public async Task<ISingleResultDto<EntityDto>> Editar(AirplaneEditarDto dto)
		{
			var evento = Mapper.Map<Airplane>(dto);

			var result = await _service.Editar(evento);

			var resultDto = new SingleResultDto<EntityDto>(result);
			resultDto.SetData(result, Mapper);

			return resultDto;
		}

		public async Task<ISingleResultDto<EntityDto>> Excluir(int id)
		{
			var result = await _service.Excluir(id);

			var resultDto = new SingleResultDto<EntityDto>(result);
			resultDto.SetData(result, Mapper);

			return resultDto;
		}
	}
}
