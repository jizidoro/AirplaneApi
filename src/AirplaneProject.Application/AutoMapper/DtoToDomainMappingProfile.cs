using AirplaneProject.Application.Dtos;
using AirplaneProject.Domain.Bases;
using AirplaneProject.Domain.Models;
using AutoMapper;

namespace AirplaneProject.Application.AutoMapper
{
	public class DtoToDomainMappingProfile : Profile
    {
		public DtoToDomainMappingProfile()
		{
            CreateMap<AirplaneIncluirDto, Airplane>();
        }
    }
}
