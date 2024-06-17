using DesafioAeC.Dominio.Entities;
using DesafioAeC.Dominio.Interfaces.Repositorios;
using DesafioAeC.Infra.Data.Repositories.Base;

namespace DesafioAeC.Infra.Data.Repositories
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public bool AutenticarUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
