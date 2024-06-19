﻿using DesafioAeC.Dominio.Arguments.Error;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Integracoes.ViaCEP.Dto
{
    public class ConsultaCepResponse
    {
        public bool Sucesso { get; set; } = false;
        public List<Error>? Erros { get; set; }
        public ConsultaCep? ConsultaCep { get; set; }

    }

    public class ConsultaCep
    {
        [JsonProperty("cep")]
        public string? Cep { get; set; }

        [JsonProperty("logradouro")]
        public string? Logradouro { get; set; }

        [JsonProperty("complemento")]
        public string? Complemento { get; set; }

        [JsonProperty("bairro")]
        public string? Bairro { get; set; }

        [JsonProperty("localidade")]
        public string? Cidade { get; set; }

        [JsonProperty("uf")]
        public string? Uf { get; set; }

        [JsonProperty("erro")]
        public string? Erro { get; set; }
    }
}
