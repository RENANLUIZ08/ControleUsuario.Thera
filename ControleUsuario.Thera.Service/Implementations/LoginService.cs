using AutoMapper;
using ControleUsuario.Thera.Domain.DTO;
using ControleUsuario.Thera.Service.Interface;
using ControleUsuario.Thera.Service.Resources;
using ControleUsuario.Thera.Service.Resources.Requested;
using System;
using System.Threading.Tasks;

namespace ControleUsuario.Thera.Service.Implementations
{
    public class LoginService : ServiceBase<LoginService>, ILoginService
    {
        public LoginService(
            IMapper mapper): base(mapper)
        { }

        public async Task<AutenticacaoDto> GerarAutenticacao(LoginDto dto)
        {
            using (var request = new RequestBase())
            {
                try
                {
                    request.SetRoute(Constants.TheraUrl, "Accounts");
                    return await request.PostAsync<AutenticacaoDto>(data: dto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
