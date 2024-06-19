using Business.Interfaces.Base;
using DesafioAeC.Dominio.Entidades;
using Integracoes.ViaCEP.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Business.Interfaces
{
    public interface IEnderecoNegocio : INegocioBase<Endereco>
    {
        public IActionResult ExportarEnderecosParaCSV();
        public Task<ConsultaCepResponse> ConsultarEnderecoPorCep(ConsultaCepRequest request);
    }
}
