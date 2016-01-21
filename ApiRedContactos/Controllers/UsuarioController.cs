using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiRedContactos.Repositorios;
using ContactosModel.Models;
using Microsoft.Practices.Unity;

namespace ApiRedContactos.Controllers
{
    public class UsuarioController : ApiController
    {
        [Dependency]
        public UsuarioRepositorio UsuarioRepositorio { get; set; }

        [ResponseType(typeof(UsuarioViewModel))]
        public IHttpActionResult GetValido(string username, string password)
        {
            var data = UsuarioRepositorio.Validar(username, password);

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(UsuarioViewModel))]
        public IHttpActionResult GetUnico(string username)
        {
            var data = UsuarioRepositorio.IsUnico(username);

            return Ok(data);
        }

        [ResponseType(typeof(UsuarioViewModel))]
        public IHttpActionResult Post(UsuarioViewModel model)
        {
            var data = UsuarioRepositorio.Add(model);

            if (data == null)
                return BadRequest();

            return Ok(data);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, UsuarioViewModel model)
        {
            var d = UsuarioRepositorio.Get(id);
            if (d == null || d.Id != model.Id)
                return NotFound();


            var data = UsuarioRepositorio.Update(model);

            if (data < 1)
                return BadRequest();

            return Ok();
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            var data = UsuarioRepositorio.Delete(id);

            if (data < 1)
                return BadRequest();

            return Ok();
        }

    }
}
