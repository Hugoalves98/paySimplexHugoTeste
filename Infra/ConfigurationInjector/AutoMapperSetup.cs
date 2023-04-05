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

            CreateMap<TarefaDTO, Tarefa>();
            CreateMap<UsuarioDTO, Usuario>();

            #endregion

            #region DomainToDTO

            CreateMap<Tarefa, TarefaDTO>();
            CreateMap<Usuario, UsuarioDTO>();

            #endregion
        }
    }
}
