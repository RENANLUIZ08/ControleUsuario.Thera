using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleUsuario.Thera.Service.Resources.Requested.TimeSheetModels
{
    public class PutTimeSheet
    {
        [JsonProperty("startLunch")]
        public DateTime StartLunch { get; set; }

        [JsonProperty("endLunch")]
        public DateTime EndLunch { get; set; }

        [JsonProperty("end")]
        public DateTime End { get; set; }

        public PutTimeSheet(int id, DateTime start, DateTime startLunch, DateTime endLunch, DateTime end)
        {
            StartLunch = startLunch;
            EndLunch = endLunch;
            End = end;
        }
    }
}
