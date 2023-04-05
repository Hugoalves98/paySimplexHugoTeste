using System.Linq.Expressions;

namespace Infra.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where);

        TEntity Create(TEntity entity);

		TEntity? Add(TEntity obj);

		bool Update(TEntity model);

        TEntity? Buscar(Expression<Func<TEntity, bool>> where);

        List<TEntity>? BuscarTodos(Expression<Func<TEntity, bool>> where);

        TEntity? BuscarPorId(int id);

		void Remove(TEntity obj);

		IQueryable<TEntity>? ObterQueryable();

		bool Delete(TEntity model);
    }
}