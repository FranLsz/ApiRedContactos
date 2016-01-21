using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositorioAdapter.Repositorio
{
    public interface IRepositorio<TModel, TViewModel, TAdapter>
    {
        ICollection<TViewModel> Get();
        TViewModel Get(params object[] keys);
        ICollection<TViewModel> Get(Expression<Func<TModel, bool>> where);
        TViewModel Add(TViewModel model);
        int Update(TViewModel model);
        int Delete(TViewModel model);
        int Delete(params object[] keys);
        int Delete(Expression<Func<TModel, bool>> where);
    }
}