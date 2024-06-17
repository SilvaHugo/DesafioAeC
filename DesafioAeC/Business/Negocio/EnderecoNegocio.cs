using Business.Interfaces;
using Business.Negocio.Base;
using DesafioAeC.Dominio.Entidades;
using DesafioAeC.Dominio.Interfaces.Servicos;

namespace Business.Negocio
{
    public class EnderecoNegocio :NegocioBase<Endereco>, IEnderecoNegocio
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoNegocio(IEnderecoService enderecoService)
            : base(enderecoService) 
        {
            _enderecoService = enderecoService;
        }
    }
}
