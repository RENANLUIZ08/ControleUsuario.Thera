using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleUsuario.Thera.Service.Resources.Requested
{
    public interface IRequestBase : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string param = "", object data = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <param name="data"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<T> PostAsync<T>(string param = "", object data = null, Dictionary<string, string> headers = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <param name="data"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<T> PutAsync<T>(string param = "", object data = null, Dictionary<string, string> headers = null);
    }
}
