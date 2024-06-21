using DesafioAeC.Dominio.Entidades;
using DesafioAeC.Dominio.Interfaces.Servicos.Base;

namespace DesafioAeC.Dominio.Interfaces.Servicos
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        public Usuario ObterUsuarioPorLogin(string login);
    }
}
