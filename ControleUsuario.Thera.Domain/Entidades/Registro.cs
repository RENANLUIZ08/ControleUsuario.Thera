using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleUsuario.Thera.Domain.Entidades
{
    public class Registro : Entity
    {
        public DateTime Start { get; private set; }
        public DateTime StartLunch { get; private set; }
        public DateTime EndLunch { get; private set; }
        public DateTime End { get; private set; }
        public TimeSpan TotalDay { get; private set; } = TimeSpan.Zero;

        public Registro()
        { }

        public Registro(int id, DateTime start, DateTime? startLunch = null, DateTime? endLunch = null, DateTime? end = null)
        {
            Id = id;
            Start = start;
            StartLunch = startLunch.GetValueOrDefault(DateTime.MinValue);
            EndLunch = endLunch.GetValueOrDefault(DateTime.MinValue);
            End = end.GetValueOrDefault(DateTime.MinValue);
        }

        public void FinalizarExpediente()
        {
            if (End != DateTime.MinValue) throw new Exception("Não é possivel finalizar um dia que ja consta como encerrado.");

            End = DateTime.Now;
            ObterTotalDia();
        }

        public void IniciarAlmoco()
        {
            if (Start == DateTime.MinValue) throw new Exception("Não é possivel iniciar o horário de almoço, pois o dia de trabalho não foi inicializado.");
            
            StartLunch = DateTime.Now;
        }

        public void FinalizarAlmoco()
        {
            if (Start == DateTime.MinValue) throw new Exception("Não é possivel finalizar o horário de almoço, pois o dia de trabalho não foi inicializado.");
            if (StartLunch == DateTime.MinValue) throw new Exception("Não é possivel finalizar o horário de almoço, pois o horario de almoço não foi inicializado.");

            EndLunch = DateTime.Now;
        }

        #region Private Methods
        private void ObterTotalDia()
        {
            if (Start == DateTime.MinValue) throw new Exception("Não é possivel computar a data de um dia sem inicializar a data de inicio do expediente");
            if (StartLunch == DateTime.MinValue) throw new Exception("Não é possivel computar a data de um dia sem inicializar o horario de almoço.");
            if (EndLunch == DateTime.MinValue) throw new Exception("Não é possivel computar a data de um dia sem finalizar o horario de almoço.");
            if (End == DateTime.MinValue) throw new Exception("Não é possivel computar a data de um dia sem inicializar a data de final do expediente");

            TotalDay = (End - Start) - (EndLunch - StartLunch);
        }

        #endregion
    }
}
