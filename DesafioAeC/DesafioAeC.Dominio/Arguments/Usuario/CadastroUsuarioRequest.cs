using System.ComponentModel.DataAnnotations;

namespace DesafioAeC.Dominio.Arguments.Usuario
{
    public class CadastroUsuarioRequest
    {
        public string? Nome { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
    }
}
