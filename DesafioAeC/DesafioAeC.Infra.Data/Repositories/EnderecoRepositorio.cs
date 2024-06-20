using DesafioAeC.Dominio.Entidades;
using DesafioAeC.Dominio.Interfaces.Repositorios;
using DesafioAeC.Infra.Data.Contexto;
using DesafioAeC.Infra.Data.Repositories.Base;

namespace DesafioAeC.Infra.Data.Repositories
{
    public class EnderecoRepositorio : RepositorioBase<Endereco>, IEnderecoRepositorio
    {
        private readonly DesafioAeCContexto _context;
        public EnderecoRepositorio(DesafioAeCContexto context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Endereco> ObterEnderecosPorUsuario(Guid idUsuario)
        {
            return _context.Enderecos.Where(x => x.UsuarioId == idUsuario).ToList();
        }
    }
}
