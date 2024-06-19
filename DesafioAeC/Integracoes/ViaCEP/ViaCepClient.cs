using Integracoes.ViaCEP.Dto;
using Newtonsoft.Json;

namespace Integracoes.ViaCEP
{
    public class ViaCepClient : IViaCepClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint = "";

        public ViaCepClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<ConsultaCepResponse> ConsultarCep(ConsultaCepRequest request)
        {

            var consultaCepResponse = new ConsultaCepResponse();
            try
            {
                var response = await _httpClient.GetAsync($"{request.Cep}/json/");
                var jsonResponse = await response.Content.ReadAsStringAsync();
                                
                if (response.IsSuccessStatusCode)
                {
                    consultaCepResponse.ConsultaCep = JsonConvert.DeserializeObject<ConsultaCep>(jsonResponse);
                    consultaCepResponse.Sucesso = consultaCepResponse.ConsultaCep?.Erro == null;

                    return consultaCepResponse;
                }

                //tratar retorno de erros
                return consultaCepResponse;
            }
            catch //(Exception ex)
            {
                //logar infos do erro
                return consultaCepResponse;
            }
        }
    }
}
