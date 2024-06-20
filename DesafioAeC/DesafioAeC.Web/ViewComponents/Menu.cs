using DesafioAeC.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DesafioAeC.Web.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessao = HttpContext.Session.GetString("UsuarioLogado");

            if (string.IsNullOrEmpty(sessao)) return null;

            var usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(sessao);

            return View(usuario);
        }
    }
}
