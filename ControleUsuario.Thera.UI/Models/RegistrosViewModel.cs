using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleUsuario.Thera.UI.Models
{
    public class RegistrosViewModel
    {
        public int Id { get; set; }
        public DateTime DataExpediente { get; set; }
        public TimeSpan InicioExpediente { get; set; }
        public TimeSpan InicioAlmoco { get; set; }
        public TimeSpan FimAlmoco { get; set; }
        public TimeSpan FimExpediente { get; set; }
    }
}