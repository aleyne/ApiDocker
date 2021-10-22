using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ApiDocker.Infra.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// Obter todos os registros
        /// </summary>
        /// <returns></returns>
        IQueryable<T> ObterTodos();

        /// <summary>
        /// Obter o registro pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T ObterPorId(object id);

        /// <summary>
        /// Obter a seleção dos registros conforme o PREDICATE informado
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<T> ObterPorPredicato(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Retornar TRUE se existir a seleção do PREDICATE informado
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Existe(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Inserir um registro na tabela
        /// </summary>
        /// <param name="entity"></param>
        void Inserir(T entity);

        /// <summary>
        /// Inserir uma lista de registro na tabela
        /// </summary>
        /// <param name="entity"></param>
        void InserirLista(List<T> entity);

        /// <summary>
        /// Remover um registro da tabela
        /// </summary>
        /// <param name="entity"></param>
        void Remover(T entity);

        /// <summary>
        /// Atualizar um registro na tabela
        /// </summary>
        /// <param name="entity"></param>
        void Atualizar(T entity);

        /// <summary>
        /// Commit para gravar as ações de Inserir, Remover e Atualizar registro
        /// </summary>
        void Salvar();

        /// <summary>
        /// Remover uma lista de registro da tabela
        /// </summary>
        /// <param name="list"></param>
        void RemoveRange(IEnumerable<T> list);
    }
}
