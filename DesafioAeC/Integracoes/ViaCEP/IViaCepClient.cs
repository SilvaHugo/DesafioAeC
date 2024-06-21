using DesafioAeC.Integracoes.ViaCEP.Dto;

namespace DesafioAeC.Integracoes.ViaCEP
{
    public interface IViaCepClient
    {
        Task<ConsultaCepResponse> ConsultarCep(ConsultaCepRequest request);
    }
}
