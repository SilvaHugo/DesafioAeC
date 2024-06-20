using Business.Interfaces.Base;
using DesafioAeC.Dominio.Entidades;
using Integracoes.ViaCEP.Dto;

namespace Business.Interfaces
{
    public interface IEnderecoNegocio : INegocioBase<Endereco>
    {
        public Task<ConsultaCepResponse> ConsultarEnderecoPorCep(ConsultaCepRequest request);

        public IEnumerable<Endereco> ObterEnderecosPorUsuario(Guid idUsuario);
    }
}
