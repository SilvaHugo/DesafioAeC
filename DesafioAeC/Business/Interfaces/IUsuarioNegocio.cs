using Business.Interfaces.Base;
using DesafioAeC.Dominio;
using DesafioAeC.Dominio.Arguments.Login;
using DesafioAeC.Dominio.Arguments.Usuario;
using DesafioAeC.Dominio.Entities;

namespace Business.Interfaces
{
    public interface IUsuarioNegocio : INegocioBase<Usuario>
    {
        public LoginResponse AutenticarUsuario(LoginRequest loginRequest);
        public CadastroUsuarioResponse CadastroUsuario(CadastroUsuarioRequest cadastroUsuarioRequest);
    }
}
