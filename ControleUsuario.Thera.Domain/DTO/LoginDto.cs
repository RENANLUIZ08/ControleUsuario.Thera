using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleUsuario.Thera.Domain.DTO
{
    public class LoginDto
    {
        [JsonProperty("userID")]
        public string UserID { get; set; }
        [JsonProperty("accessKey")]
        public string AccessKey { get; set; }
        [JsonProperty("grantType")]
        public string GrantType { get; } = "password";

        public LoginDto(string userId, string accessKey)
        {
            UserID = userId;
            AccessKey = accessKey;
        }
    }
}
