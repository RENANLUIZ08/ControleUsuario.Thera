using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleUsuario.Thera.Service.Implementations
{
    public abstract class ServiceBase<TEntity> where TEntity : class
    {
        protected readonly IMapper _mapper;

        public ServiceBase(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
