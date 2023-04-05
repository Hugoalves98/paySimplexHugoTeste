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

            #endregion

            #region DomainToDTO

            CreateMap<Tarefa, TarefaDTO>();

            #endregion
        }
    }
}
