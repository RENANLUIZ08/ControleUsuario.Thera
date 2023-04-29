using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleUsuario.Thera.Domain.Entidades
{
    public class UsuarioRegistro : Entity
    {
        public string UsuarioExpediente { get; private set; }

        public UsuarioRegistro(string nomeUsuario)
        {
            if (string.IsNullOrEmpty(nomeUsuario)) throw new ArgumentNullException("Para iniciar o expediente é preciso informar o usuário");
            
            var now = DateTime.Now;
            UsuarioExpediente = nomeUsuario + "|" + now.ToString("yyyy-MM-yyyy");
        }
    }
}
