using ApiRedContactos.Models;
using ContactosModel.Models;
using RepositorioAdapter.Adapter;

namespace ApiRedContactos.Adapters
{
    public class UsuarioAdapter : BaseAdapter<Usuario, UsuarioViewModel>
    {
        public override Usuario FromViewModel(UsuarioViewModel model)
        {
            return new Usuario()
            {
                Id = model.Id,
                Foto = model.Foto,
                Username = model.Username,
                Apellidos = model.Apellidos,
                Nombre = model.Nombre,
                Password = model.Password
            };
        }

        public override UsuarioViewModel FromModel(Usuario model)
        {
            return new UsuarioViewModel()
            {
                Id = model.Id,
                Foto = model.Foto,
                Username = model.Username,
                Apellidos = model.Apellidos,
                Nombre = model.Nombre,
                Password = model.Password
            };
        }
    }
}