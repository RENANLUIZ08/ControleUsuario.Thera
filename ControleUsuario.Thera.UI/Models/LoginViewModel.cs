using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleUsuario.Thera.UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Por favor, preencher o campo de usuário.")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Por favor, preencher o campo de senha.")]
        public string Senha { get; set; }
    }
}