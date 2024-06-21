using AutoMapper;
using DesafioAeC.Dominio.Arguments.Login;
using DesafioAeC.Dominio.Arguments.Usuario;
using DesafioAeC.Dominio.Entidades;
using DesafioAeC.Dominio.Shared;
using DesafioAeC.Integracoes.ViaCEP.Dto;
using DesafioAeC.Web.ViewModels;

namespace DesafioAeC.Web.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Enderecos
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<EnderecoViewModel, Endereco>()
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep.Replace("-", ""))); ;
            //CEP
            CreateMap<ConsultaCep, CepViewModel>();
            //Login
            CreateMap<LoginViewModel, LoginRequest>()
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => HashSenha.HashPassword(src.Senha)));
            //Usuarios
            CreateMap<CadastrarUsuarioViewModel, CadastroUsuarioRequest>()
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => HashSenha.HashPassword(src.Senha)));
            CreateMap<CadastroUsuarioRequest, Usuario>();
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}
