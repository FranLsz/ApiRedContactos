using System.Collections.Generic;
using System.Linq;

namespace RepositorioAdapter.Adapter
{
    public abstract class BaseAdapter<TModel, TViewModel> : IAdapter<TModel, TViewModel>
    {
        public abstract TModel FromViewModel(TViewModel model);

        public abstract TViewModel FromModel(TModel model);

        public ICollection<TModel> FromViewModel(ICollection<TViewModel> model)
        {
            return model.Select(FromViewModel).ToList();
        }

        public ICollection<TViewModel> FromModel(ICollection<TModel> model)
        {
            return model.Select(FromModel).ToList();
        }
    }
}