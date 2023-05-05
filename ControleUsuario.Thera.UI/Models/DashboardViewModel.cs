using ControleUsuario.Thera.Domain.DTO;
using ControleUsuario.Thera.Service.Resources.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleUsuario.Thera.UI.Models
{
    public class DashboardViewModel
    {
        public string Usuario { get; set; }
        public List<RegistroDto> Registros { get; set; }

        public DashboardViewModel(string usuario, List<RegistroDto> registros)
        {
            Usuario = usuario;
            Registros = registros;
        }
    }
}