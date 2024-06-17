using DesafioAeC.Dominio.Arguments.Error;
using System.Text.Json.Serialization;

namespace Integracoes.ViaCEP.Dto
{
    public class ConsultaCepResponse
    {
        public bool Sucesso { get; set; }
        public List<Error>? Erros { get; set; }
        public ConsultaCep? ConsultaCep { get; set; }

    }

    public class ConsultaCep
    {
        [JsonPropertyName("cep")]
        public string? Cep { get; set; }

        [JsonPropertyName("logradouro")]
        public string? Logradouro { get; set; }

        [JsonPropertyName("complemento")]
        public string? Complemento { get; set; }

        [JsonPropertyName("bairro")]
        public string? Bairro { get; set; }

        [JsonPropertyName("localidade")]
        public string? Cidade { get; set; }

        [JsonPropertyName("uf")]
        public string? Uf { get; set; }
    }
}
