﻿using AutoMapper;
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
            CreateMap<TarefaInsertDTO, Tarefa>();
			CreateMap<UsuarioDTO, Usuario>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.ToLower()));

            #endregion

            #region DomainToDTO

            CreateMap<Tarefa, TarefaDTO>();
            CreateMap<Tarefa, TarefaInsertDTO>();
            CreateMap<Usuario, UsuarioDTO>();

            #endregion
        }
    }
}
