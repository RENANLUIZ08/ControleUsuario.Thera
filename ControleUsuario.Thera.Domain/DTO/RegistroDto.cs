using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleUsuario.Thera.Domain.DTO
{
    public class RegistroDto
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime StartLunch { get; set; } = DateTime.MinValue;
        public DateTime EndLunch { get; set; } = DateTime.MinValue;
        public DateTime End { get; set; } = DateTime.MinValue;
        public string TotalDay { get; set; } = DateTime.MinValue.ToString("HH\\:mm\\:ss");
    }
}
