using AutoMapper;
using DesafioAeC.Business.Interfaces;
using DesafioAeC.Dominio.Arguments.Login;
using DesafioAeC.Dominio.Arguments.Usuario;
using DesafioAeC.Web.FluentValidation;
using DesafioAeC.Web.Util.Interface;
using DesafioAeC.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAeC.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioNegocio _usuarioNegocio;
        private readonly IMapper _mapper;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioNegocio usuarioNegocio, IMapper mapper, ISessao sessao)
        {
            _usuarioNegocio = usuarioNegocio;
            _mapper = mapper;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            if (_sessao.ObterDadosUsuarioLogado() != null) return RedirectToAction("Index", "Endereco");
            ViewBag.ActiveTab = "Login";
            return View();
        }

        public IActionResult Cadastrar()
        {
            ViewBag.ActiveTab = "Cadastrar";
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginViewModel loginViewModel)
        {
            try
            {
                var validator = new LoginViewModelValidator();
                var validationResult = validator.Validate(loginViewModel);

                if (validationResult.IsValid)
                {
                    var retorno = _usuarioNegocio.AutenticarUsuario(_mapper.Map<LoginRequest>(loginViewModel));

                    if (retorno.UsuarioAutenticado)
                    {
                        _sessao.CriarSessaoUsuario(_mapper.Map<UsuarioViewModel>(retorno.Usuario));
                        TempData["SuccessMessage"] = retorno.Mensagem;
                        return RedirectToAction("Index", "Endereco");
                    }

                    TempData["ErrorMessage"] = retorno.Mensagem;
                    return RedirectToAction("Index", "Login");
                }

                string msgErro = "";

                foreach (var erro in validationResult.Errors)
                    msgErro += erro.ErrorMessage + " ";


                TempData["ErrorMessage"] = msgErro;
                return RedirectToAction("Index", "Login");
            }
            catch //(Exception ex)
            {
                //logar erro
                TempData["ErrorMessage"] = "Ocorreu um erro ao realizar o login. Tente novamente mais tarde!";
                return View(nameof(Index));
            }
        }

        public IActionResult Logout()
        {
            _sessao.RemoverSessaoUsuario();
            TempData["SuccessMessage"] = "Logout efetuado com sucesso!";
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarUsuarioViewModel cadastrarUsuarioViewModel)
        {
            try
            {
                var validator = new CadastrarUsuarioViewModelValidator();
                var validationResult = validator.Validate(cadastrarUsuarioViewModel);

                if (validationResult.IsValid)
                {
                    var retorno = _usuarioNegocio.CadastroUsuario(_mapper.Map<CadastroUsuarioRequest>(cadastrarUsuarioViewModel));

                    if (!retorno.Sucesso)
                    {
                        TempData["ErrorMessage"] = retorno.Mensagem;
                        return RedirectToAction("Cadastrar", "Login");
                    }

                    TempData["SuccessMessage"] = retorno.Mensagem;
                    return RedirectToAction("Index", "Login");
                }

                string msgErro = "";

                foreach (var erro in validationResult.Errors)
                    msgErro += erro.ErrorMessage + " ";


                TempData["ErrorMessage"] = msgErro;
                return RedirectToAction("Cadastrar", "Login");
            }
            catch //(Exception)
            {
                TempData["ErrorMessage"] = "Não foi possível cadastrar o usuário. Tente novamente mais tarde.";
                return RedirectToAction(nameof(Cadastrar));
            }
        }
    }
}
