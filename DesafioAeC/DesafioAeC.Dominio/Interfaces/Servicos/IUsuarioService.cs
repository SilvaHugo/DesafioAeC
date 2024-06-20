using DesafioAeC.Dominio.Arguments.Login;
using DesafioAeC.Dominio.Entities;
using DesafioAeC.Dominio.Interfaces.Servicos.Base;

namespace DesafioAeC.Dominio.Interfaces.Servicos
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        public Usuario ObterUsuarioPorLogin(string login);
    }
}
