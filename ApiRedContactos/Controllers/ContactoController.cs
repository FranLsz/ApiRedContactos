using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiRedContactos.Repository;
using DataModel.ViewModel;
using Microsoft.Practices.Unity;

namespace ApiRedContactos.Controllers
{
    public class ContactoController : ApiController
    {
        [Dependency]
        public UsuarioRepository UsuarioRepositorio { get; set; }
        [Dependency]
        public ContactoRepository ContactoRepositorio { get; set; }

        [ResponseType(typeof(UsuarioModel))]
        public IHttpActionResult Get(int id)
        {
            var data = ContactoRepositorio.Get(o => o.IdUsuario == id);
            var contactos = data.Select(c => UsuarioRepositorio.Get(c.IdAmigo)).ToList();

            if (data == null)
                return NotFound();
            return Ok(contactos);
        }
    }
}
