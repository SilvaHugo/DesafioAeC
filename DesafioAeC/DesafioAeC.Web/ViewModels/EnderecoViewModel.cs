using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioAeC.Web.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [ScaffoldColumn(false)]
        public DateTime CriadoEm { get; set; }
        
        [ScaffoldColumn(false)]
        public DateTime? AlteradoEm { get; set; }

        [Required(ErrorMessage = "Preencha o campo CEP.")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "Formato inválido para o CEP.")]
        public string? Cep { get; set; }

        [Required(ErrorMessage = "Preencha o campo Logradouro.")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres.")]
        public string? Logradouro { get; set; }

        [MaxLength(255, ErrorMessage = "Máximo 144 caracteres.")]
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "Preencha o campo Bairro.")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres.")]
        public string? Bairro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cidade.")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres.")]
        public string? Cidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo UF.")]
        [MaxLength(2, ErrorMessage = "Máximo 2 caracteres.")]
        public string? Uf { get; set; }

        [Required(ErrorMessage = "Preencha o campo Número.")]
        [DisplayName("Número")]
        public string? Numero { get; set; }

        [ScaffoldColumn(false)]
        public Guid UsuarioId { get; set; }

        [ScaffoldColumn(false)]
        public string CepFormatado => !string.IsNullOrEmpty(Cep) && Cep.Length == 8 ? $"{Cep.Substring(0, 5)}-{Cep.Substring(5, 3)}" : "";
    }
}
