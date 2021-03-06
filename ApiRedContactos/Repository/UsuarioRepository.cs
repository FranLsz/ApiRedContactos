﻿/*
The next code was generated by Repository Pattern Generator.
Be free to modify this file.

This extension was developed and designed by Francisco López Sánchez.
*/

using System.Data.Entity;
using System.Linq;
using Repository.Adapter;
using Repository.Model;
using Repository.Repository;
using DataModel.ViewModel;

namespace ApiRedContactos.Repository
{
    public class UsuarioRepository : EntityFrameworkRepository<Usuario, UsuarioModel, UsuarioAdapter>
    {
        public UsuarioRepository(DbContext context) : base(context) { }

        public UsuarioModel Validar(string username, string password)
        {
            var data = Get(o => o.Username == username && o.Password == password);

            if (data.Any())
                return data.First();
            return null;
        }

        public override UsuarioModel Add(UsuarioModel model)
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
