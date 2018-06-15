using AutoMapper;
using GEA.AvaliacaoTecnica.Application.ViewModels;
using GEA.AvaliacaoTecnica.Domain.Models;

namespace GEA.AvaliacaoTecnica.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Empresa, EmpresaViewModel>().ReverseMap();
            CreateMap<Veiculo, VeiculoViewModel>().ReverseMap();
            CreateMap<CompetenciaAberta, CompetenciaAberturaViewModel>().ReverseMap();
            CreateMap<CompetenciaFechada, CompetenciaFechadaViewModel>().ReverseMap();
            CreateMap<RegistroEntrada, RegistroEntradaViewModel>().ReverseMap();
            CreateMap<RegistroSaida, RegistroSaidaViewModel>().ReverseMap();
            CreateMap<RegistroEmail, RegistroEmailViewModel>().ReverseMap();
        }
    }
}
