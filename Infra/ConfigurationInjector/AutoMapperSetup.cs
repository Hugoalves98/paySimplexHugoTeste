using AutoMapper;
using Infra.DTOs;
using Infra.Entities;

namespace Infra.ConfigurationInjector
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region DTOToDomain

            CreateMap<EmployeeDTO, Employee>();
            CreateMap<ProjectDTO, Project>();
            CreateMap<MeetingDTO, Meeting>();
            //CreateMap<AddressDTO, Address>();
            //CreateMap<RateUserDTO, RateUser>();
            //CreateMap<RecoverPasswordDTO, RecoverPassword>();
            //CreateMap<AboutMeDTO, AboutMe>();

            #endregion

            #region DomainToDTO

            CreateMap<Employee, EmployeeDTO>();
            CreateMap<Project, ProjectDTO>();
            CreateMap<Meeting, MeetingDTO>();
            //CreateMap<Address, AddressDTO>();
            //CreateMap<RateUser, RateUserDTO>();
            //CreateMap<RecoverPassword, RecoverPasswordDTO>();
            //CreateMap<Service, ServiceDTO>();
            //CreateMap<User, UserDTO>();
            //CreateMap<Service, ServiceWithUserDTO>();
            //CreateMap<AboutMe, AboutMeDTO>();

            #endregion
        }
    }
}
