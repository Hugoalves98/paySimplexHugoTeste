using AutoMapper;

namespace Infra.ConfigurationInjector
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region DTOToDomain

            //CreateMap<AddressDTO, Address>();
            //CreateMap<RateUserDTO, RateUser>();
            //CreateMap<RecoverPasswordDTO, RecoverPassword>();
            //CreateMap<AboutMeDTO, AboutMe>();

            #endregion

            #region DomainToDTO

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
