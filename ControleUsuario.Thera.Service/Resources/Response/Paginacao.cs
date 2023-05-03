using ControleUsuario.Thera.Service.Resources.Response.TimeSheetModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleUsuario.Thera.Service.Resources.Response
{
    public class Paginacao
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("items")]
        public List<TimeSheet> Items { get; set; }
    }
}
