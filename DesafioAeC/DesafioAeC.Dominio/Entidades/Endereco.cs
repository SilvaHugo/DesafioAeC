using DesafioAeC.Dominio.Entidades.Base;

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
        public Guid IdUsuario { get; set; }
    }
}
