using DesafioAeC.Business.Interfaces.Base;
using DesafioAeC.Dominio;
using DesafioAeC.Dominio.Arguments.Login;
using DesafioAeC.Dominio.Arguments.Usuario;
using DesafioAeC.Dominio.Entidades;

namespace DesafioAeC.Business.Interfaces
{
    public interface IUsuarioNegocio : INegocioBase<Usuario>
    {
        public LoginResponse AutenticarUsuario(LoginRequest loginRequest);
        public CadastroUsuarioResponse CadastroUsuario(CadastroUsuarioRequest cadastroUsuarioRequest);
    }
}
