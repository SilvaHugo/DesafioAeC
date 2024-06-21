using System.ComponentModel.DataAnnotations;

namespace DesafioAeC.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Preencha o login")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "O campo Login não deve conter espaços ou caracteres especiais.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Preencha a senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
