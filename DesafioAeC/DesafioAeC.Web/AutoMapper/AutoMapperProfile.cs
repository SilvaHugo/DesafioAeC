using AutoMapper;
using DesafioAeC.Dominio.Entidades;
using DesafioAeC.Web.ViewModels;

namespace DesafioAeC.Web.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<EnderecoViewModel, Endereco>()
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep.Replace("-", ""))); ;
        }
    }
}
