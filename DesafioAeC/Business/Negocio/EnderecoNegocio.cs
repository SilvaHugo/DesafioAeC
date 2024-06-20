using Business.Interfaces;
using Business.Negocio.Base;
using DesafioAeC.Dominio.Entidades;
using DesafioAeC.Dominio.Interfaces.Servicos;
using Integracoes.ViaCEP;
using Integracoes.ViaCEP.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Business.Negocio
{
    public class EnderecoNegocio :NegocioBase<Endereco>, IEnderecoNegocio
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IViaCepClient _viaCepClient;

        public EnderecoNegocio(IEnderecoService enderecoService, IViaCepClient viaCepClient)
            : base(enderecoService) 
        {
            _enderecoService = enderecoService;
            _viaCepClient = viaCepClient;
        }

        public async Task<ConsultaCepResponse> ConsultarEnderecoPorCep(ConsultaCepRequest request) => await _viaCepClient.ConsultarCep(request);
        
    }
}
