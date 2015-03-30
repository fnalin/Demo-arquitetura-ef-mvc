using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoEFMVC.App.Apresentacao.Web.Infra
{
    public static class ClienteExtension
    {
        static ClienteExtension()
        {
            AutoMapper.Mapper.CreateMap<Dominio.Entidade.Cliente, ViewModels.ClienteVM>()
               //.ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
               //.ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
               //.ForMember(dest => dest.Nascimento, opt => opt.MapFrom(src => src.Nascimento))
               //.ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo))
               //.ForMember(dest => dest.Foto, opt => opt.MapFrom(src => src.Foto))
               ;

            AutoMapper.Mapper.CreateMap<ViewModels.ClienteVM, Dominio.Entidade.Cliente>()
               //.ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
               //.ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
               //.ForMember(dest => dest.Nascimento, opt => opt.MapFrom(src => src.Nascimento))
               //.ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo))
               //.ForMember(dest => dest.Foto, opt => opt.MapFrom(src => src.Foto))
               ;

            AutoMapper.Mapper.CreateMap<Dominio.Entidade.Foto, ViewModels.FotoVM>();
            AutoMapper.Mapper.CreateMap<ViewModels.FotoVM, Dominio.Entidade.Foto>();
        }

        public static Dominio.Entidade.Cliente ToCliente(this ViewModels.ClienteVM clienteVM, Dominio.Entidade.Cliente objDestino = null)
        {
            return AutoMapper.Mapper.Map(clienteVM, objDestino ?? new Dominio.Entidade.Cliente());
        }

        public static ViewModels.ClienteVM ToClienteVM(this Dominio.Entidade.Cliente aluno, ViewModels.ClienteVM objDestino = null)
        {
            return AutoMapper.Mapper.Map(aluno, objDestino ?? new ViewModels.ClienteVM());
        }

    }
}