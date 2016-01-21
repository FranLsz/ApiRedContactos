using System;
using System.Data.Entity;
using System.Linq;
using ApiRedContactos.Adapters;
using ApiRedContactos.Models;
using ContactosModel.Models;
using RepositorioAdapter.Repositorio;

namespace ApiRedContactos.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorioEntity<Usuario, UsuarioViewModel, UsuarioAdapter>
    {
        public UsuarioRepositorio(DbContext context) : base(context)
        {
        }

        public UsuarioViewModel Validar(string username, string password)
        {
            var data = Get(o => o.Username == username && o.Password == password);

            if (data.Any())
                return data.First();
            return null;
        }

        public override UsuarioViewModel Add(UsuarioViewModel model)
        {
            if (IsUnico(model.Username))
                return base.Add(model);

            return null;
        }

        public bool IsUnico(string username)
        {
            var data = Get(o => o.Username == username);

            return !data.Any();
        }

    }
}