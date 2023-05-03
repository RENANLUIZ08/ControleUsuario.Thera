using ControleUsuario.Thera.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleUsuario.Thera.UI.Controllers
{
    public class RegistrosController : Controller
    {
        private readonly IRegistroService _registroService;

        public RegistrosController(IRegistroService registroService)
        {
            _registroService = registroService;
        }

        public ActionResult Dashboard()
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Index", controllerName: "Login");
            }

            return View();
        }

        private bool IsAuthenticated()
        => Request.Cookies["cookieToken"].Value != null;

    }
}
