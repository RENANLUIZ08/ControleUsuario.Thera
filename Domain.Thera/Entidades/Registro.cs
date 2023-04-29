using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleUsuario.Thera.Domain.Entidades
{
    public class Registro : Entity
    {
        public string UserName { get; private set; }
        public UsuarioRegistro UsuarioRegistro { get; private set; }
        public TimeSpan InicioExpediente { get; private set; }
        public TimeSpan InicioAlmoco { get; private set; }
        public TimeSpan FimAlmoco { get; private set; }
        public TimeSpan FimExpediente { get; private set; }
        public TimeSpan TotalExpediente { get; private set; }

        private DateTime _DataExpediente => ObterDataExpediete();

        public void IniciarExpediente(string nomeUsuario)
        {
            var usuarioRegistro = new UsuarioRegistro(nomeUsuario);
            var nowTime = DateTime.Now.TimeOfDay;

            Id = Guid.NewGuid();
            InicioExpediente = nowTime;
            InicioAlmoco = TimeSpan.Zero;
            FimAlmoco = TimeSpan.Zero;
            FimExpediente = TimeSpan.Zero;
            TotalExpediente = TimeSpan.Zero;
            UsuarioRegistro = usuarioRegistro;
        }

        public void FinalizarExpediente()
        {
            FimExpediente = DateTime.Now.TimeOfDay;
            ObterTotalDia();
        }

        public void IniciarAlmoco()
        {
            if (_DataExpediente == DateTime.MinValue) throw new Exception("Não é possivel iniciar o horário de almoço, pois o dia de trabalho não foi inicializado.");
            InicioAlmoco = DateTime.Now.TimeOfDay;
        }

        public void FinalizarAlmoco()
        {
            if (_DataExpediente == DateTime.MinValue) throw new Exception("Não é possivel finalizar o horário de almoço, pois o dia de trabalho não foi inicializado.");
            FimAlmoco = DateTime.Now.TimeOfDay;
        }


        #region Private Methods
        private void ObterTotalDia()
        {
            if (_DataExpediente == DateTime.MinValue) throw new Exception("Não é possivel computar a data de um dia não iniciado.");
            if (InicioExpediente == TimeSpan.Zero || InicioExpediente == TimeSpan.MinValue) throw new Exception("Não é possivel computar a data de um dia sem inicializar a data de inicio do expediente");
            if (InicioAlmoco == TimeSpan.Zero) throw new Exception("Não é possivel computar a data de um dia sem inicializar o horario de almoço.");
            if (FimAlmoco == TimeSpan.Zero) throw new Exception("Não é possivel computar a data de um dia sem finalizar o horario de almoço.");
            if (FimExpediente == TimeSpan.Zero || InicioExpediente == TimeSpan.MinValue) throw new Exception("Não é possivel computar a data de um dia sem inicializar a data de final do expediente");

            TotalExpediente = (FimExpediente - InicioExpediente) - (FimAlmoco - InicioAlmoco);
        }

        private DateTime ObterDataExpediete()
        {
            if (UsuarioRegistro == null || string.IsNullOrEmpty(UsuarioRegistro.UsuarioExpediente)) throw new ArgumentNullException("Não foi possivel obter a data de registro do usuário, tente novamente.");

            var separarUsuarioRegistro = UsuarioRegistro.UsuarioExpediente.Split('|');
            var dataObtida = DateTime.MinValue;
            if (separarUsuarioRegistro.Length > 1) DateTime.TryParse(separarUsuarioRegistro[1], out dataObtida);

            return dataObtida;
        }

        #endregion
    }
}
