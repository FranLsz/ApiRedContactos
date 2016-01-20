using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositorioAdapter.Repositorio
{
    public interface IRepositorio<TEntity, TModel, TAdapter>
    {
        ICollection<TModel> Get();
        TModel Get(params object[] keys);
        ICollection<TModel> Get(Expression<Func<TModel, bool>> where);
        TModel Add(TModel model);
        int Update(TModel model);
        int Delete(TModel model);
        int Delete(params object[] keys);
        int Delete(Expression<Func<TModel, bool>> where);
    }
}