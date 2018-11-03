namespace Banicharnica.App.Core
{
    using AutoMapper;
    using App.Core.Dtos;
    using Models;

    public class BanicharnicaProfile : Profile
    {
        public BanicharnicaProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, ManagerDto>()
                .ForMember(dest => dest.EmployeesDto, from => from.MapFrom(x => x.ManagerEmployees))
                .ReverseMap();
            CreateMap<Employee, EmployeePersonalInfoDto>().ReverseMap();
        }
    }
}
