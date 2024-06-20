using DesafioAeC.Dominio.Entidades;
using DesafioAeC.Dominio.Interfaces.Repositorios.Base;

namespace DesafioAeC.Dominio.Interfaces.Repositorios
{
    public interface IEnderecoRepositorio : IRepositorioBase<Endereco>
    {
        public IEnumerable<Endereco> ObterEnderecosPorUsuario(Guid idUsuario);
    }
}
