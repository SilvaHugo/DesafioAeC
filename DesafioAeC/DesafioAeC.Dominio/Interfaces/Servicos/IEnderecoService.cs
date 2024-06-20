using DesafioAeC.Dominio.Entidades;
using DesafioAeC.Dominio.Interfaces.Servicos.Base;

namespace DesafioAeC.Dominio.Interfaces.Servicos
{
    public interface IEnderecoService : IServiceBase<Endereco>
    {
        public IEnumerable<Endereco> ObterEnderecosPorUsuario(Guid idUsuario);
    }
}
