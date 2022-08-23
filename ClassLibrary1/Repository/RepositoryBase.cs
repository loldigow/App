using SuperCore.Interfaces.Repository;
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
        protected Realm _realm;

        private void CarregueBanco()
        {
            _realm = Realm.GetInstance(RepositoryMigration.CurrentConfiguration);
        }

        public void Adicione(TEntity entity)
        {
            CarregueBanco();
            _realm.Write(() => _realm.Add(entity));
        }

        public void AdicioneTodos(IList<TEntity> entity)
        {
            CarregueBanco();
            foreach (var i in entity)
            {
                Adicione(i);
            }
        }

        public TEntity ObtenhaPeloId(int id)
        {
            try
            {

                CarregueBanco();
                return _realm.Find<TEntity>(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<TEntity> ObtenhaPorExpressao(Expression<Func<TEntity, bool>> predicate)
        {
            CarregueBanco();
            if (predicate == null)
                return ObtenhaTodos();
            return _realm.All<TEntity>().Where(predicate).ToList();
        }

        public List<TEntity> ObtenhaTodos()
        {
            CarregueBanco();
            return _realm.All<TEntity>().ToList();
        }

        public void RemovaPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public void RemovaTodos()
        {
            CarregueBanco();
            _realm.Write(() =>
            {
                var dados = _realm.All<TEntity>();
                _realm.RemoveRange(dados);
            });
        }
    }

    public class RepositoryMigration
    {
        public static RealmConfiguration CurrentConfiguration =>
            new RealmConfiguration
            {
                SchemaVersion = 2,
                MigrationCallback = (migration, oldSchemaVersion) =>
                {

                }
            };
    }

}
