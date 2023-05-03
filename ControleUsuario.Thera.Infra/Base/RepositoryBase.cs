using ControleUsuario.Thera.Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace ControleUsuario.Thera.Infra.Registro
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ControleUsuarioContext _context;

        public RepositoryBase(ControleUsuarioContext context)
        {
            _context = context;
        }

        public void CreateOrUpdate(TEntity entity)
        {
            _context.Set<TEntity>().AddOrUpdate(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression == null) return _context.Set<TEntity>().AsNoTracking().AsParallel().ToList();
            return _context.Set<TEntity>().AsNoTracking().Where(expression).AsParallel().ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
