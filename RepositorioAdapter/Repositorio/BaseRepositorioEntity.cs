using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using RepositorioAdapter.Adapter;

namespace RepositorioAdapter.Repositorio
{
    public class BaseRepositorioEntity<TModel, TViewModel, TAdapter> : IRepositorio<TModel, TViewModel, TAdapter>
        where TAdapter : IAdapter<TModel, TViewModel>, new()
        where TModel : class
        where TViewModel : class
    {
        protected DbContext Context;

        protected DbSet<TModel> DbSet
        {
            get { return Context.Set<TModel>(); }
        }

        public TAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                    _adapter = new TAdapter();
                return _adapter;
            }
        }

        private TAdapter _adapter;


        public BaseRepositorioEntity(DbContext context)
        {
            Context = context;
        }

        public ICollection<TViewModel> Get()
        {
            return Adapter.FromModel(DbSet.ToList());
        }

        public TViewModel Get(params object[] keys)
        {
            var data = DbSet.Find(keys);
            return Adapter.FromModel(data);
        }

        public ICollection<TViewModel> Get(Expression<Func<TModel, bool>> @where)
        {
            var data = DbSet.Where(where);
            return Adapter.FromModel(data.ToList());
        }

        public TViewModel Add(TViewModel model)
        {
            var guardado = Adapter.FromViewModel(model);
            DbSet.Add(guardado);
            try
            {
                Context.SaveChanges();
                return Adapter.FromModel(guardado);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Update(TViewModel model)
        {
            var guardar = Adapter.FromViewModel(model);
            Context.Entry(guardar).State = EntityState.Modified;
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Delete(TViewModel model)
        {
            var data = Adapter.FromViewModel(model);
            Context.Entry(data).State = EntityState.Deleted;
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Delete(params object[] keys)
        {
            var data = DbSet.Find(keys);
            DbSet.Remove(data);
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Delete(Expression<Func<TModel, bool>> where)
        {
            var data = DbSet.Where(where);
            DbSet.RemoveRange(data);
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}