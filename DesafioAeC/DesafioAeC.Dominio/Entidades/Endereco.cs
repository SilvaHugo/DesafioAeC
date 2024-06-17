using DesafioAeC.Dominio.Entidades.Base;
using DesafioAeC.Dominio.Entities;

namespace DesafioAeC.Dominio.Entidades
{
    public class Endereco : EntidadeBase
    {
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        public int? Numero { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
