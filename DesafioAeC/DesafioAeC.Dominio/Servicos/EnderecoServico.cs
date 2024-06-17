using DesafioAeC.Dominio.Entidades;
using DesafioAeC.Dominio.Interfaces.Repositorios;
using DesafioAeC.Dominio.Interfaces.Servicos;
using DesafioAeC.Dominio.Servicos.Base;

namespace DesafioAeC.Dominio.Servicos
{
    public class EnderecoServico : ServicoBase<Endereco>, IEnderecoService
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;
        public EnderecoServico(IEnderecoRepositorio enderecoRepositorio)
            : base(enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }
    }
}
