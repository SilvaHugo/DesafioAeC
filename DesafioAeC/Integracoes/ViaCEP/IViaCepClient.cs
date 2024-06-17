using Integracoes.ViaCEP.Dto;

namespace Integracoes.ViaCEP
{
    public interface IViaCepClient
    {
        Task<ConsultaCepResponse> ConsultarCep(ConsultaCepRequest request);
    }
}
