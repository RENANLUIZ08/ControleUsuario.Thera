using ControleUsuario.Thera.Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ControleUsuario.Thera.Infra.Registro
{
    public class RegistroRepository : RepositoryBase<Domain.Entidades.Registro>, IRegistroRepository
    {
        public RegistroRepository(ControleUsuarioContext context) : base(context)
        { }
    }
}
