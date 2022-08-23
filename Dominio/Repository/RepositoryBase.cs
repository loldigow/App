using Core.Interfaces.Repository;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : RealmObject, new()
    {
        protected readonly Realm _realm;
        public RepositoryBase()
        {
            try
            {
                //_realm = Realm.GetInstance(RepositoryMigration.CurrentConfiguration);
            }
            catch (Exception ex)
            {

            }
        }
        public void Adicione(TEntity entity)
        {
            _realm.Write(() => _realm.Add(entity));
        }

        public void AdicioneTodos(IList<TEntity> entity)
        {
            foreach(var i in entity)
            {
                Adicione(i);
            }
        }

        public TEntity ObtenhaPeloId(int id)
        {
            return _realm.Find<TEntity>(id);
        }

        public List<TEntity> ObtenhaPorExpressao(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                return ObtenhaTodos();
            return _realm.All<TEntity>().Where(predicate).ToList();
        }

        public List<TEntity> ObtenhaTodos()
        {
            return _realm.All<TEntity>().ToList();
        }

        public void RemovaPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public void RemovaTodos()
        {
            throw new NotImplementedException();
        }
    }
}
