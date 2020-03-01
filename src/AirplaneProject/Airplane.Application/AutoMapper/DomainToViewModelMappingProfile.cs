using AutoMapper;
using AirplaneProject.Application.ViewModels;
using AirplaneProject.Domain.Models;

namespace AirplaneProject.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
