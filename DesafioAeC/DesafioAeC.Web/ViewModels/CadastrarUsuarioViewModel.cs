using System.ComponentModel.DataAnnotations;

namespace DesafioAeC.Web.ViewModels
{
    public class CadastrarUsuarioViewModel
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 255 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "O campo Nome não deve conter caracteres especiais.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo Login é obrigatório.")]
        [StringLength(50, ErrorMessage = "O Login deve ter no máximo 255 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "O campo Login não deve conter espaços ou caracteres especiais.")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A Senha deve ter no mínimo 6 caracteres.")]
        public string? Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
        public string? ConfirmarSenha { get; set; }
    }
}
