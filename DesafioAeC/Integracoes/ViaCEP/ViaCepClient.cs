using Integracoes.ViaCEP.Dto;
using Newtonsoft.Json;

namespace Integracoes.ViaCEP
{
    public class ViaCepClient : IViaCepClient
    {
        private readonly HttpClient _httpClient;

        public ViaCepClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ConsultaCepResponse> ConsultarCep(ConsultaCepRequest request)
        {
            var consultaCepResponse = new ConsultaCepResponse();

            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{request.Cep}/json/");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            consultaCepResponse.Sucesso = response.IsSuccessStatusCode;
            if (response.IsSuccessStatusCode)
            {
                consultaCepResponse.ConsultaCep = JsonConvert.DeserializeObject<ConsultaCep>(jsonResponse);
                return consultaCepResponse;
            }

            //tratar retorno de erros
            return consultaCepResponse;
        }
    }
}
