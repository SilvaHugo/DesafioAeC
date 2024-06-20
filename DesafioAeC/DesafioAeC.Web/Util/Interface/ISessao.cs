using DesafioAeC.Web.ViewModels;

namespace DesafioAeC.Web.Util.Interface
{
    public interface ISessao
    {
        void CriarSessaoUsuario(UsuarioViewModel usuario);
        void RemoverSessaoUsuario();
        UsuarioViewModel ObterDadosUsuarioLogado();
    }
}
