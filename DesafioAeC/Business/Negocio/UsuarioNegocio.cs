using AutoMapper;
using DesafioAeC.Business.Interfaces;
using DesafioAeC.Business.Negocio.Base;
using DesafioAeC.Dominio;
using DesafioAeC.Dominio.Arguments.Login;
using DesafioAeC.Dominio.Arguments.Usuario;
using DesafioAeC.Dominio.Entidades;
using DesafioAeC.Dominio.Interfaces.Servicos;
using DesafioAeC.Dominio.Shared;

namespace DesafioAeC.Business.Negocio
{
    public class UsuarioNegocio : NegocioBase<Usuario>, IUsuarioNegocio
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public UsuarioNegocio(IUsuarioService usuarioService, IMapper mapper)
            : base(usuarioService)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        public LoginResponse AutenticarUsuario(LoginRequest loginRequest)
        {
            LoginResponse response = new LoginResponse();
            Usuario usuario = _usuarioService.ObterUsuarioPorLogin(loginRequest.Login);

            if (usuario != null)
            {
                var senhaValida = HashSenha.VerificarSenha(loginRequest.Senha, usuario.Senha, false);

                if (senhaValida)
                {
                    response.UsuarioAutenticado = true;
                    response.Usuario = usuario;
                    response.Mensagem = "Login efetuado com sucesso!";
                }
                else
                {
                    response.UsuarioAutenticado = false;
                    response.Mensagem = "Usuário e/ou senha inválido(s)";
                }
            }

            return response;
        }

        public CadastroUsuarioResponse CadastroUsuario(CadastroUsuarioRequest cadastroUsuarioRequest)
        {
            CadastroUsuarioResponse response = new CadastroUsuarioResponse();
            Usuario usuario = _usuarioService.ObterUsuarioPorLogin(cadastroUsuarioRequest.Login);

            if (usuario != null)
            {
                response.Sucesso = false;
                response.Mensagem = "Usuário já registrado na base. Forneça um Login diferente";
            }
            else
            {
                _usuarioService.Inserir(_mapper.Map<Usuario>(cadastroUsuarioRequest));
                response.Sucesso = true;
                response.Mensagem = "Cadastro efetuado com sucesso.";
            }
            return response;
        }
    }
}
