using DesafioAeC.Dominio.Entidades;
using DesafioAeC.Dominio.Interfaces.Repositorios;
using DesafioAeC.Infra.Data.Contexto;
using DesafioAeC.Infra.Data.Repositories.Base;

namespace DesafioAeC.Infra.Data.Repositories
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        private readonly DesafioAeCContexto _context;
        public UsuarioRepositorio(DesafioAeCContexto context) : base(context)
        {
            _context = context;
        }

        public Usuario ObterUsuarioPorLogin(string login)
        {
            return _context.Usuarios.SingleOrDefault(x => x.Login == login);
        }
    }
}
