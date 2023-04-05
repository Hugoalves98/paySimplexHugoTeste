using Infra.Data;
using Infra.Entities;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infra.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly Context _context;

        protected DbSet<TEntity> DbSet
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }

        public Repository(Context context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where)//(Expression<Func<TEntity, bool>>)Faz com que para chamar o metodo tenha que usar uma Expressão Lambda
        {
            try
            {
                return DbSet.AsNoTracking().Where(where);
            }
            catch
            {
                throw;
            }
        }

        public TEntity? Find(Expression<Func<TEntity, bool>> where)//(Expression<Func<TEntity, bool>>)Faz com que para chamar o metodo tenha que usar uma Expressão Lambda
        {
            try
            {
                return DbSet.AsNoTracking().FirstOrDefault(where);//O AsNoTracking tbm serve para que possamos atualizar um dado
            }
            catch
            {
                throw;
            }
        }

        public TEntity? FindById(int id)
        {
            try
            {
                return _context.Set<TEntity>().Find(id);
            }
            catch
            {
                throw;
            }
        }

        public List<TEntity>? FindAll(Expression<Func<TEntity, bool>> where) => DbSet.AsNoTracking().Where(where).ToList();
       
        public TEntity Create(TEntity entity)
        {
            if (entity is BaseEntity)
            {
                (entity as BaseEntity).CreationDate = DateTime.Now;
            }

            DbSet.Add(entity);

            Save();

            return entity;
        }

        public bool Update(TEntity model)
        {
            try
            {
                if (model is BaseEntity)
                {
                    (model as BaseEntity).UpdateDate = DateTime.Now;
                }

                var entry = _context.Entry(model);

                DbSet.Attach(model);

                entry.State = EntityState.Modified;

                return Save() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

		public TEntity Add(TEntity obj)
		{
			try
			{
				DbSet.Add(obj);

				Save();

				return obj;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public IQueryable<TEntity> ObterQueryable()
		{
			try
			{
				IQueryable<TEntity> retorno = _context.Set<TEntity>();

				return retorno;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

        public bool Delete(TEntity model)
        {
            try
            {
                if (model is BaseEntity)
                {
                    (model as BaseEntity).IsDeleted = true;

                    var _entry = _context.Entry(model);

                    DbSet.Attach(model);

                    _entry.State = EntityState.Modified;
                }
                else
                {
                    var _entry = _context.Entry(model);
                    DbSet.Attach(model);
                    _entry.State = EntityState.Deleted;
                }

                return Save() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

		public void Remove(TEntity obj)
		{
			try
			{
				_context.Set<TEntity>().Remove(obj);

				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public int Save()
		{
			try
			{
				return _context.SaveChanges();
			}
			catch (Exception)
			{

				throw;
			}

		}

		public void Dispose()
        {
            try
            {
                if (_context != null)
                    _context.Dispose();

                GC.SuppressFinalize(this);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}