using ControleUsuario.Thera.Domain.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleUsuario.Thera.UI.Controllers
{
    public class ControllerBase : Controller
    {
        protected AutenticacaoDto ObterAutenticado()
        {
            AutenticacaoDto resultado = null;
            var cookie = Request?.Cookies["cookieToken"];
            var obterValue = cookie?.Value;

            if (obterValue != null) resultado = JsonConvert.DeserializeObject<AutenticacaoDto>(obterValue);

            return resultado;
        }
    }
}