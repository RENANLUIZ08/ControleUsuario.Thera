using Domain.Thera.Exceptions;
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
            if (End != DateTime.MinValue && End.TimeOfDay != TimeSpan.Parse("00:00:00")) throw new TheraException("Não é possivel finalizar um dia que ja consta como encerrado.");

            End = ObterDataUTC();
        }

        public void IniciarAlmoco()
        {
            if (Start == DateTime.MinValue) throw new TheraException("Não é possivel iniciar o horário de almoço, pois o dia de trabalho não foi inicializado.");
            
            StartLunch = ObterDataUTC();
        }

        public void FinalizarAlmoco()
        {
            if (Start == DateTime.MinValue) throw new TheraException("Não é possivel finalizar o horário de almoço, pois o dia de trabalho não foi inicializado.");
            if (StartLunch == DateTime.MinValue) throw new TheraException("Não é possivel finalizar o horário de almoço, pois o horario de almoço não foi inicializado.");

            EndLunch = ObterDataUTC();
        }

        public string ObterTotalDia()
        {
            bool diaFinalizado = Start != DateTime.MinValue && (StartLunch != DateTime.MinValue && StartLunch.TimeOfDay != TimeSpan.Parse("00:00:00")) && (EndLunch != DateTime.MinValue && EndLunch.TimeOfDay != TimeSpan.Parse("00:00:00")) && (End != DateTime.MinValue && End.TimeOfDay != TimeSpan.Parse("00:00:00"));
            if (diaFinalizado)
            {
                var horasTrabalhadas = ((End - Start) - (EndLunch - StartLunch));
                return string.Format("{0:D2}:{1:D2}:{2:D2}", horasTrabalhadas.Hours, horasTrabalhadas.Minutes, horasTrabalhadas.Seconds);
            }

            return "00:00:00";
        }

        private DateTime ObterDataUTC()
        => DateTime.Now.AddHours(-3);
    }
}
