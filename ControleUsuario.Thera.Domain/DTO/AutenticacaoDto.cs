using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ControleUsuario.Thera.Domain.DTO
{
    public class AutenticacaoDto
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }

        [JsonProperty("tokenType")]
        public string TokenType { get; set; }

        [JsonProperty("expiresIn")]
        public string ExpiresIn { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public AutenticacaoDto(string accessToken, string refreshToken, string tokenType, string expiresIn, string name)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            TokenType = tokenType;
            ExpiresIn = expiresIn;
            Name = name;
        }
    }
}
