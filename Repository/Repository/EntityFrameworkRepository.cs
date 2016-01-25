﻿/*
The next code was generated by Repository Pattern Generator.
Be free to modify this file.

This extension was developed and designed by Francisco López Sánchez.
*/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Repository.Adapter;

namespace Repository.Repository
{
    public class EntityFrameworkRepository<TEntity, TModel, TAdapter> : IRepository<TEntity, TModel, TAdapter>
        where TAdapter : IAdapter<TEntity, TModel>, new()
        where TEntity : class
        where TModel : class
    {
        protected DbContext Context;

        protected DbSet<TEntity> DbSet => Context.Set<TEntity>();

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

        public EntityFrameworkRepository(DbContext context)
        {
            Context = context;
        }

        public virtual ICollection<TModel> Get()
        {
            return Adapter.FromModel(DbSet.ToList());
        }

        public virtual TModel Get(params object[] keys)
        {
            var data = DbSet.Find(keys);
            return Adapter.FromModel(data);
        }

        public virtual ICollection<TModel> Get(Expression<Func<TEntity, bool>> where)
        {
            var data = DbSet.Where(where);
            return Adapter.FromModel(data.ToList());
        }

        public virtual TModel Add(TModel model)
        {
            var data = Adapter.FromViewModel(model);
            data = DbSet.Add(data);
            try
            {
                Context.SaveChanges();
                return Adapter.FromModel(data);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual int Update(TModel model)
        {
            var data = Adapter.FromViewModel(model);
            Context.Entry(data).State = EntityState.Modified;
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public virtual int Delete(params object[] keys)
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

        public virtual int Delete(TModel model)
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

        public virtual int Delete(Expression<Func<TEntity, bool>> where)
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