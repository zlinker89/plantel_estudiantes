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
    public class PadreController : ApiController
    {
        private plantel_estudiantesContext db = new plantel_estudiantesContext();

        // GET api/Padre
        public IQueryable<Padre> GetPadres()
        {
            return db.Padres;
        }

        // GET api/Padre/5
        [ResponseType(typeof(Padre))]
        public async Task<IHttpActionResult> GetPadre(int id)
        {
            Padre padre = await db.Padres.FindAsync(id);
            if (padre == null)
            {
                return NotFound();
            }

            return Ok(padre);
        }

        // PUT api/Padre/5
        public async Task<IHttpActionResult> PutPadre(int id, Padre padre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != padre.id)
            {
                return BadRequest();
            }

            db.Entry(padre).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PadreExists(id))
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

        // POST api/Padre
        [ResponseType(typeof(Padre))]
        public async Task<IHttpActionResult> PostPadre(Padre padre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Padres.Add(padre);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = padre.id }, padre);
        }

        // DELETE api/Padre/5
        [ResponseType(typeof(Padre))]
        public async Task<IHttpActionResult> DeletePadre(int id)
        {
            Padre padre = await db.Padres.FindAsync(id);
            if (padre == null)
            {
                return NotFound();
            }

            db.Padres.Remove(padre);
            await db.SaveChangesAsync();

            return Ok(padre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PadreExists(int id)
        {
            return db.Padres.Count(e => e.id == id) > 0;
        }
    }
}