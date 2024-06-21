using DesafioAeC.Business.Interfaces;
using DesafioAeC.Business.Negocio.Base;
using DesafioAeC.Dominio.Entidades;
using DesafioAeC.Dominio.Interfaces.Servicos;
using DesafioAeC.Integracoes.ViaCEP;
using DesafioAeC.Integracoes.ViaCEP.Dto;

namespace DesafioAeC.Business.Negocio
{
    public class EnderecoNegocio : NegocioBase<Endereco>, IEnderecoNegocio
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

        public IEnumerable<Endereco> ObterEnderecosPorUsuario(Guid idUsuario)
        {
            return _enderecoService.ObterEnderecosPorUsuario(idUsuario);
        }
    }
}
