using ControleUsuario.Thera.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControleUsuario.Thera.Service.Interface
{
    public interface ILoginService
    {
        Task<AutenticacaoDto> GerarAutenticacao(LoginDto dto);
    }
}
