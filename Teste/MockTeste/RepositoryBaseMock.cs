using SuperCore.Entidade;
using SuperCore.Interfaces.Repository;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Teste.MockTeste
{
    public class RepositoryBaseMock<TEntity> : IRepository<TEntity> where TEntity : RealmObject, new()
    {
        private List<TEntity> _bancoDeDadosMock = new List<TEntity>();
        public void Adicione(TEntity entity)
        {
            _bancoDeDadosMock.Add(entity);
        }

        public void AdicioneTodos(IList<TEntity> entity)
        {
            _bancoDeDadosMock.AddRange(entity);
        }

        public TEntity ObtenhaPeloId(int id)
        {
            return null;
        }

        public List<TEntity> ObtenhaPorExpressao(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                return ObtenhaTodos();
            // return _bancoDeDadosMock.Where(predicate).ToList();
            return null;
            //Gravidade	Código	Descrição	Projeto	Arquivo	Linha	Estado de Supressão
            //Erro CS0268  O tipo importado 'EntidadeBase' é inválido. Ele contém uma dependência de tipo base circular.Teste C:\WorkRo\Sigga\Sigga\Teste\MockTeste\RepositoryBaseMock.cs 44  Ativo

        }

        public List<TEntity> ObtenhaTodos()
        {
            return _bancoDeDadosMock;
        }

        public void RemovaPeloId(int id)
        {
           //_bancoDeDadosMock.Where(x => x.Id == id);
            //throw new NotImplementedException();
        }

        public void RemovaTodos()
        {
            //throw new NotImplementedException();
        }
    }
}
