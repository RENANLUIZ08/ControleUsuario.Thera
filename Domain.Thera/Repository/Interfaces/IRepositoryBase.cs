using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControleUsuario.Thera.Domain.Repository.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null);
    }
}
