using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SuperCore.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : new()
    {
        TEntity ObtenhaPeloId(int id);
        List<TEntity> ObtenhaPorExpressao(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> ObtenhaTodos();

        void Adicione(TEntity entity);
        void AdicioneTodos(IList<TEntity> entity);

        void RemovaPeloId(int id);
        void RemovaTodos();
    }
}
