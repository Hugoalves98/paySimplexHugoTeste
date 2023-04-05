using System.Linq.Expressions;

namespace Infra.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        TEntity? Insert(TEntity obj);

        bool Update(TEntity obj);

        bool Delete(TEntity obj);

        TEntity? Buscar(Expression<Func<TEntity, bool>> where);
        
        List<TEntity>? BuscarTodos(Expression<Func<TEntity, bool>> where);

        TEntity? BuscarPorId(int id);
    }
}
