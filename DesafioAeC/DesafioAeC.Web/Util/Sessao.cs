using DesafioAeC.Web.Util.Interface;
using DesafioAeC.Web.ViewModels;
using Newtonsoft.Json;

namespace DesafioAeC.Web.Util
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly string _chaveSession = "UsuarioLogado";

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void CriarSessaoUsuario(UsuarioViewModel usuario) => _httpContext?.HttpContext?.Session.SetString(_chaveSession, JsonConvert.SerializeObject(usuario));
        

        public UsuarioViewModel ObterDadosUsuarioLogado()
        {
            string usuarioLogado = _httpContext.HttpContext.Session.GetString(_chaveSession);

            if (string.IsNullOrEmpty(usuarioLogado)) return null;

            return JsonConvert.DeserializeObject<UsuarioViewModel>(usuarioLogado);    
        }

        public void RemoverSessaoUsuario() => _httpContext.HttpContext.Session.Remove(_chaveSession);
        
    }
}
