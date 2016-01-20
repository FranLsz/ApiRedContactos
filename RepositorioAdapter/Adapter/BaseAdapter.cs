using System.Collections.Generic;
using System.Linq;

namespace RepositorioAdapter.Adapter
{
    public abstract class BaseAdapter<TEntity, TModel> : IAdapter<TEntity, TModel>
    {
        public abstract TEntity FromViewModel(TModel model);

        public abstract TModel FromModel(TEntity model);

        public ICollection<TEntity> FromViewModel(ICollection<TModel> model)
        {
            return model.Select(FromViewModel).ToList();
        }

        public ICollection<TModel> FromModel(ICollection<TEntity> model)
        {
            return model.Select(FromModel).ToList();
        }
    }
}