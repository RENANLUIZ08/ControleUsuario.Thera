using Autofac.Integration.Mvc;
using AutoMapper;
using ControleUsuario.Thera.Domain.DTO;
using ControleUsuario.Thera.Domain.Entidades;
using ControleUsuario.Thera.Service.Resources.Requested;
using ControleUsuario.Thera.Service.Resources.Requested.TimeSheetModels;
using ControleUsuario.Thera.Service.Resources.Response;
using ControleUsuario.Thera.Service.Resources.Response.TimeSheetModels;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Web.Mvc;
using Unity;

namespace ControleUsuario.Thera.UI.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure(UnityContainer container)
        {
            // Crie o perfil de mapeamento
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MyMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            container.RegisterInstance(mapper);
        }
    }

    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<Registro, RegistroDto>()
                .ForMember(dest => dest.TotalDay, opt => opt.MapFrom(src => src.ObterTotalDia()));

            CreateMap<RegistroDto, Registro>();

            CreateMap<TimeSheet, Registro>()
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Start))
                .ForMember(dest => dest.StartLunch, opt => opt.MapFrom(src => src.StartLunch))
                .ForMember(dest => dest.EndLunch, opt => opt.MapFrom(src => src.EndLunch))
                .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.End));

            CreateMap<PutTimeSheet, Registro>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Start, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}