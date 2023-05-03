using ControleUsuario.Thera.Domain.DTO;
using ControleUsuario.Thera.Service.Interface;
using ControleUsuario.Thera.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.DynamicData;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ControleUsuario.Thera.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult
                {
                    Data = new { success = false, obj = ModelState.Select(s => new { key = s.Key.ToLower(), error = s.Value.Errors.Select(x => x.ErrorMessage) }) }
                };
            }

            try
            {
                var autenticacao = await Authentication(model.Usuario, model.Senha);
                return new JsonResult
                {
                    Data = new { success = false, obj = autenticacao },
                };
            }
            catch { }

            return new JsonResult
            {
                Data = new { success = false, message = "Erro ao realizar o login, tente novamente." }
            };
        }

        private async Task<AutenticacaoDto> Authentication(string username, string password)
        => await _loginService.GerarAutenticacao(new LoginDto(username, password));
    }
}