using DesafioAeC.Dominio.Entidades;

namespace DesafioAeC.Dominio;

public class LoginResponse
{
    public bool UsuarioAutenticado { get; set; } = false;
    public string? Mensagem { get; set; }
    public Usuario? Usuario { get; set; }

}
