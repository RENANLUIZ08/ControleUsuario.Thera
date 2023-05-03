using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleUsuario.Thera.UI.Models
{
    public class DashboardViewModel
    {
        public string Usuario { get; set; }
        public List<RegistrosViewModel> Registros { get; set; }
    }
}