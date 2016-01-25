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
    public class MensajeController : ApiController
    {
        [Dependency]
        public MensajeRepository MensajeRepository { get; set; }

        [ResponseType(typeof(MensajeModel))]
        public IHttpActionResult Get()
        {
            var data = MensajeRepository.Get();

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(MensajeModel))]
        public IHttpActionResult Get(int id)
        {
            var data = MensajeRepository.Get(id);

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(MensajeModel))]
        public IHttpActionResult GetByReceptor(int receptorId)
        {
            var data = MensajeRepository.Get(o => o.IdDestino == receptorId);

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(MensajeModel))]
        public IHttpActionResult GetByEmisor(int emisorId)
        {
            var data = MensajeRepository.Get(o => o.IdOrigen == emisorId);

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(MensajeModel))]
        public IHttpActionResult Post(MensajeModel model)
        {
            var data = MensajeRepository.Add(model);

            if (data == null)
                return BadRequest();

            return Ok(data);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, MensajeModel model)
        {
            var d = MensajeRepository.Get(id);
            if (d == null || d.Id != model.Id)
                return NotFound();


            var data = MensajeRepository.Update(model);

            if (data < 1)
                return BadRequest();

            return Ok();
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            var data = MensajeRepository.Delete(id);

            if (data < 1)
                return BadRequest();

            return Ok();
        }
    }
}
