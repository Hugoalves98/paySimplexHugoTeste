using Infra.Entities;
using Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        public readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public bool Delete(TEntity obj) => _repository.Delete(obj);

        public TEntity? Buscar(Expression<Func<TEntity, bool>> where) => _repository.Buscar(where);

        public List<TEntity>? BuscarTodos(Expression<Func<TEntity, bool>> where) => _repository.BuscarTodos(where);

        public TEntity? BuscarPorId(int id) => _repository.BuscarPorId(id);

        public TEntity? Insert(TEntity obj) => _repository.Create(obj);

        public bool Update(TEntity obj) => _repository.Update(obj);
    }
}
