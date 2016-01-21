using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace RepositorioAdapter.Adapter
{
    // va a saber quien es el model y el viewModel, y se va a encargar de enlazar

    /// <summary>
    /// Transforma TEntity a TModel y viceversa
    /// </summary>
    /// <typeparam name="TModel"> Objeto entidad de la base de datos </typeparam>
    /// <typeparam name="TViewModel"> Objeto de transferencia, es lo que mando </typeparam>
    public interface IAdapter<TModel, TViewModel>
    {
        TModel FromViewModel(TViewModel model);
        TViewModel FromModel(TModel model);
        ICollection<TModel> FromViewModel(ICollection<TViewModel> model);
        ICollection<TViewModel> FromModel(ICollection<TModel> model);
    }
}