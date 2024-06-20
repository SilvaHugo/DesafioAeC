using AutoMapper;
using Business.Interfaces;
using DesafioAeC.Dominio.Entidades;
using DesafioAeC.Web.Filters;
using DesafioAeC.Web.FluentValidation;
using DesafioAeC.Web.Util.Interface;
using DesafioAeC.Web.ViewModels;
using Integracoes.ViaCEP.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DesafioAeC.Web.Controllers
{
    [UsuarioLogadoFilter]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoNegocio _enderecoNegocio;
        private readonly IMapper _mapper;
        private readonly ISessao _sessao;
        private readonly UsuarioViewModel _usuarioLogado;

        public EnderecoController(IEnderecoNegocio enderecoNegocio, IMapper mapper, ISessao sessao)
        {
            _enderecoNegocio = enderecoNegocio;
            _mapper = mapper;
            _sessao = sessao;
            _usuarioLogado = _sessao.ObterDadosUsuarioLogado();
        }

        // GET: EnderecoController
        public ActionResult Index()
        {
            var enderecoViewModel = _mapper.Map<IEnumerable<EnderecoViewModel>>(_enderecoNegocio.ObterEnderecosPorUsuario(_usuarioLogado.Id));
            return View(enderecoViewModel);
        }

        // GET: EnderecoController/Detalhes/guid
        public ActionResult Detalhes(Guid id)
        {
            var endereco = _enderecoNegocio.ObterPorId(id);

            if(endereco.UsuarioId != _usuarioLogado.Id)            
                return RedirectToAction(nameof(Index));
            
            var enderecoViewModel = _mapper.Map<EnderecoViewModel>(endereco);
            return View(enderecoViewModel);
        }

        // GET: EnderecoController/Adicionar
        public ActionResult Adicionar()
        {
            return View();
        }

        // POST: EnderecoController/Adicionar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(EnderecoViewModel endereco)
        {
            try
            {
                var validator = new EnderecoViewModelValidator();
                var validationResult = validator.Validate(endereco);

                if (validationResult.IsValid)
                {
                    endereco.UsuarioId = _usuarioLogado.Id;
                    var enderecoEntity = _mapper.Map<Endereco>(endereco);
                    _enderecoNegocio.Inserir(enderecoEntity);

                    TempData["SuccessMessage"] = "Endereço criado com sucesso!";
                    return RedirectToAction(nameof(Detalhes), new { id = enderecoEntity.Id });
                }

                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                TempData["ErrorMessage"] = "Ocorreu um erro ao criar o endereço. Tente novamente mais tarde!";
                return View(endereco);
            }
            catch
            {
                //logar infos do erro
                TempData["ErrorMessage"] = "Ocorreu um erro ao criar o endereço. Tente novamente mais tarde!";
                return View();
            }
        }

        // GET: EnderecoController/Alterar/guid
        public ActionResult Alterar(Guid id)
        {
            var endereco = _enderecoNegocio.ObterPorId(id);

            if (endereco.UsuarioId != _usuarioLogado.Id)
                return RedirectToAction(nameof(Index));

            var enderecoViewModel = _mapper.Map<EnderecoViewModel>(endereco);

            return View(enderecoViewModel);
        }

        // POST: EnderecoController/Alterar/guid
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(EnderecoViewModel endereco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var enderecoEntity = _mapper.Map<Endereco>(endereco);
                    _enderecoNegocio.Alterar(enderecoEntity);

                    TempData["SuccessMessage"] = "Endereço alterado com sucesso!";
                    return RedirectToAction(nameof(Detalhes), new { id = enderecoEntity.Id });
                }

                TempData["ErrorMessage"] = "Ocorreu um erro ao alterar o endereço. Tente novamente mais tarde!";
                return View();
            }
            catch
            {
                //logar infos do erro
                TempData["ErrorMessage"] = "Ocorreu um erro ao alterar o endereço. Tente novamente mais tarde!";
                return View();
            }
        }

        // GET: EnderecoController/Remover/guid
        public ActionResult Remover(Guid id)
        {
            var endereco = _enderecoNegocio.ObterPorId(id);
            var enderecoViewModel = _mapper.Map<EnderecoViewModel>(endereco);

            return View(enderecoViewModel);
        }

        // POST: EnderecoController/Remover/guid
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfimarRemover(Guid id, IFormCollection collection)
        {
            try
            {
                var endereco = _enderecoNegocio.ObterPorId(id);
                _enderecoNegocio.Remover(endereco);

                TempData["SuccessMessage"] = "Endereço removido com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["ErrorMessage"] = "Ocorreu um erro ao remover o endereço. Tente novamente mais tarde!";
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> ConsultarEnderecoPorCep(string cep)
         {
            try
            {
                var consultaCepResponse = await _enderecoNegocio.ConsultarEnderecoPorCep(new ConsultaCepRequest() { Cep = cep });

                if (consultaCepResponse.Sucesso)
                {
                    var cepViewModel = _mapper.Map<CepViewModel>(consultaCepResponse.ConsultaCep);
                    return Json(cepViewModel);
                }

                return Json(null);
            }
            catch //(Exception ex)
            {
                //logar infos do erro
                return Json(null);
            }            
        }

        public FileResult ExportarEnderecosParaCSV()
        {
            var enderecos = _enderecoNegocio.ObterEnderecosPorUsuario(_usuarioLogado.Id);
            var enderecoViewModels = _mapper.Map<IEnumerable<EnderecoViewModel>>(enderecos);

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Id,Cep,Logradouro,Número,Complemento,Bairro,Cidade,UF");

            foreach (var endereco in enderecoViewModels)
                stringBuilder.AppendLine($"{endereco.Id},{endereco.CepFormatado},{endereco.Logradouro},{endereco.Numero},{endereco.Complemento},{endereco.Bairro},{endereco.Cidade},{endereco.Uf}");


            var content = stringBuilder.ToString();
            var bytes = Encoding.UTF8.GetPreamble().Concat(Encoding.UTF8.GetBytes(content)).ToArray();
            var output = new MemoryStream(bytes);

            return File(output, "text/csv", "Enderecos.csv");
        }
    }
}
