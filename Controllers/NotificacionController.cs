using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using plantel_estudiantes.Models;

namespace plantel_estudiantes.Controllers
{
    public class NotificacionController : ApiController
    {
        private plantel_estudiantesContext db = new plantel_estudiantesContext();

        // GET api/Notificacion
        public IQueryable<Notificacion> GetNotificacions()
        {
            return db.Notificacions;
        }

        // GET api/Notificacion/5
        [ResponseType(typeof(Notificacion))]
        public async Task<IHttpActionResult> GetNotificacion(int id)
        {
            Notificacion notificacion = await db.Notificacions.FindAsync(id);
            if (notificacion == null)
            {
                return NotFound();
            }

            return Ok(notificacion);
        }

        // PUT api/Notificacion/5
        public async Task<IHttpActionResult> PutNotificacion(int id, Notificacion notificacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notificacion.id)
            {
                return BadRequest();
            }

            db.Entry(notificacion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificacionExists(id))
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

        // POST api/Notificacion
        [ResponseType(typeof(Notificacion))]
        public async Task<IHttpActionResult> PostNotificacion(Notificacion notificacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Notificacions.Add(notificacion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = notificacion.id }, notificacion);
        }

        // DELETE api/Notificacion/5
        [ResponseType(typeof(Notificacion))]
        public async Task<IHttpActionResult> DeleteNotificacion(int id)
        {
            Notificacion notificacion = await db.Notificacions.FindAsync(id);
            if (notificacion == null)
            {
                return NotFound();
            }

            db.Notificacions.Remove(notificacion);
            await db.SaveChangesAsync();

            return Ok(notificacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NotificacionExists(int id)
        {
            return db.Notificacions.Count(e => e.id == id) > 0;
        }
    }
}