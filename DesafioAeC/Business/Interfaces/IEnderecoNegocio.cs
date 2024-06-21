using DesafioAeC.Business.Interfaces.Base;
using DesafioAeC.Dominio.Entidades;
using DesafioAeC.Integracoes.ViaCEP.Dto;

namespace DesafioAeC.Business.Interfaces
{
    public interface IEnderecoNegocio : INegocioBase<Endereco>
    {
        public Task<ConsultaCepResponse> ConsultarEnderecoPorCep(ConsultaCepRequest request);

        public IEnumerable<Endereco> ObterEnderecosPorUsuario(Guid idUsuario);
    }
}
