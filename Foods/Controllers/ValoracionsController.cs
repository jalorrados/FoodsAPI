using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Foods.Models;

namespace Foods.Controllers
{
    public class ValoracionsController : ApiController
    {
        private FoodsEntities db = new FoodsEntities();

        // GET: api/Valoracions
        public IQueryable<Valoracion> GetValoracion()
        {
            return db.Valoracion;
        }

        // GET: api/Valoracions/5
        [ResponseType(typeof(Valoracion))]
        public IHttpActionResult GetValoracion(int id)
        {
            Valoracion valoracion = db.Valoracion.Find(id);
            if (valoracion == null)
            {
                return NotFound();
            }

            return Ok(valoracion);
        }

        // PUT: api/Valoracions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutValoracion(int id, Valoracion valoracion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != valoracion.Id_Valoracion)
            {
                return BadRequest();
            }

            db.Entry(valoracion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValoracionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Valoracions
        [ResponseType(typeof(Valoracion))]
        public IHttpActionResult PostValoracion(Valoracion valoracion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Valoracion.Add(valoracion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = valoracion.Id_Valoracion }, valoracion);
        }

        // DELETE: api/Valoracions/5
        [ResponseType(typeof(Valoracion))]
        public IHttpActionResult DeleteValoracion(int id)
        {
            Valoracion valoracion = db.Valoracion.Find(id);
            if (valoracion == null)
            {
                return NotFound();
            }

            db.Valoracion.Remove(valoracion);
            db.SaveChanges();

            return Ok(valoracion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ValoracionExists(int id)
        {
            return db.Valoracion.Count(e => e.Id_Valoracion == id) > 0;
        }
    }
}