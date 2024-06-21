using DesafioAeC.Dominio.Entidades;
using DesafioAeC.Dominio.Interfaces.Repositorios.Base;

namespace DesafioAeC.Dominio.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        public Usuario ObterUsuarioPorLogin(string login);
    }
}
