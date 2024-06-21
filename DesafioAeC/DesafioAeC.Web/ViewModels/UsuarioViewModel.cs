namespace DesafioAeC.Web.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string ObterPrimeiroNome(string nomeCompleto)
        {
            if (string.IsNullOrWhiteSpace(nomeCompleto))
            {
                return string.Empty;
            }

            var nomes = nomeCompleto.Split(' ');
            return nomes[0];
        }
    }
}
