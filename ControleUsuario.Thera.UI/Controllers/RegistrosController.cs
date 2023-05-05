using ControleUsuario.Thera.Domain.DTO;
using ControleUsuario.Thera.Service.Interface;
using ControleUsuario.Thera.UI.Models;
using Domain.Thera.Enum;
using Domain.Thera.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ControleUsuario.Thera.UI.Controllers
{
    public class RegistrosController : ControllerBase
    {
        private AutenticacaoDto _autenticado;
        private readonly IRegistroService _registroService;

        public RegistrosController(IRegistroService registroService)
        {
            _registroService = registroService;
        }

        [HttpGet]
        public async Task<ActionResult> Dashboard()
        {
            _autenticado = ObterAutenticado();
            if (_autenticado == null) return RedirectToAction("Index", controllerName: "Login");

            try
            {
                var allTimeSheets = await _registroService.GetAllTimeSheets(_autenticado);
                return View(new DashboardViewModel(_autenticado.Name, allTimeSheets));
            }
            catch (Exception)
            {
                HttpCookie cookie = new HttpCookie("cookieToken");
                cookie.Expires = DateTime.MinValue;
                Response.Cookies.Add(cookie);

                return RedirectToAction("Index", controllerName: "Login");
            }
            
        }

        [HttpPost]
        public async Task<JsonResult> SendTimeSheet(ETimeSheet type, RegistroDto registroDto = null)
        {
            _autenticado = ObterAutenticado();
            if (_autenticado == null) return new JsonResult { Data = new { success = false, result = "" } };

            try
            {
                if (type == ETimeSheet.Start) return new JsonResult { Data = new { success = true, result = await _registroService.CreateTimeSheet(_autenticado) } };

                return new JsonResult { Data = new { success = true, result = await _registroService.UpdateTimeSheet(_autenticado, registroDto, type) } };
            }
            catch (TheraException ex)
            {
                return new JsonResult { Data = new { success = false, error = ex.Message } }; ;
            }
            catch (Exception) 
            {
                return new JsonResult { Data = new { success = false, result = "" } };
            }
           
        }     

    }
}
