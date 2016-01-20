using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace RepositorioAdapter.Adapter
{
    // va a saber quien es el model y el viewModel, y se va a encargar de enlazar

    /// <summary>
    /// Transforma TEntity a TModel y viceversa
    /// </summary>
    /// <typeparam name="TEntity"> Objeto entidad de la base de datos </typeparam>
    /// <typeparam name="TModel"> Objeto de transferencia, es lo que mando </typeparam>
    public interface IAdapter<TEntity, TModel>
    {
        TEntity FromViewModel(TModel model);
        TModel FromModel(TEntity model);
        ICollection<TEntity> FromViewModel(ICollection<TModel> model);
        ICollection<TModel> FromModel(ICollection<TEntity> model);
    }
}