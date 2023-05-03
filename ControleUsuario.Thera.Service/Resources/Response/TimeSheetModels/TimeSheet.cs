using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleUsuario.Thera.Service.Resources.Response.TimeSheetModels
{
    public class TimeSheet : TimeSheetCreated
    {
        [JsonProperty("startLunch")]
        public DateTime StartLunch { get; set; }

        [JsonProperty("endLunch")]
        public DateTime EndLunch { get; set; }

        [JsonProperty("end")]
        public DateTime End { get; set; }
    }
}
