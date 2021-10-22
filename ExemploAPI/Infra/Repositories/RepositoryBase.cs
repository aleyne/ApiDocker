using ApiDocker.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiDocker.Infra.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly APIContext _context;
        public RepositoryBase(APIContext context)
        {
            _context = context;
        }

        public IQueryable<T> ObterTodos()
        {
            return _context.Set<T>();
        }

        public T ObterPorId(object id)
        {
            return _context.Set<T>().Find(id);
        }
        public IQueryable<T> ObterPorPredicato(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public bool Existe(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }

        public void Inserir(T entity)
        {
            _context.Add(entity);
        }

        public void InserirLista(List<T> entity)
        {
            _context.AddRange(entity);
        }

        public void Remover(T entity)
        {
            _context.Remove(entity);
        }
        public void Atualizar(T entity)
        {
            _context.Update(entity);
        }
        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> list)
        {
            _context.RemoveRange(list);
        }
    }
}
