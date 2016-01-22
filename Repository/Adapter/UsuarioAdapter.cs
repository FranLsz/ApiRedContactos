﻿/*
The next code was generated by Repository Pattern Generator.
Be free to modify this file.

This extension was developed and designed by Francisco López Sánchez.
*/

using Repository.Model;
using DataModel.ViewModel;

namespace Repository.Adapter
{
    public class UsuarioAdapter : Adapter<Usuario, UsuarioModel>
    {
        public override Usuario FromViewModel(UsuarioModel model)
        {
            return new Usuario()
            {
                Id = model.Id,
                Username = model.Username,
                Password = model.Password,
                Nombre = model.Nombre,
                Apellidos = model.Apellidos,
                Foto = model.Foto
            };
        }

        public override UsuarioModel FromModel(Usuario model)
        {
            return new UsuarioModel()
            {
                Id = model.Id,
                Username = model.Username,
                Password = model.Password,
                Nombre = model.Nombre,
                Apellidos = model.Apellidos,
                Foto = model.Foto
            };
        }
    }
}