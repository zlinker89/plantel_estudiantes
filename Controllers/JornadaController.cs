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
    public class JornadaController : ApiController
    {
        private plantel_estudiantesContext db = new plantel_estudiantesContext();

        // GET api/Jornada
        public IQueryable<Jornada> GetJornadas()
        {
            return db.Jornadas;
        }

        // GET api/Jornada/5
        [ResponseType(typeof(Jornada))]
        public async Task<IHttpActionResult> GetJornada(int id)
        {
            Jornada jornada = await db.Jornadas.FindAsync(id);
            if (jornada == null)
            {
                return NotFound();
            }

            return Ok(jornada);
        }

        // PUT api/Jornada/5
        public async Task<IHttpActionResult> PutJornada(int id, Jornada jornada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jornada.id)
            {
                return BadRequest();
            }

            db.Entry(jornada).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JornadaExists(id))
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

        // POST api/Jornada
        [ResponseType(typeof(Jornada))]
        public async Task<IHttpActionResult> PostJornada(Jornada jornada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Jornadas.Add(jornada);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = jornada.id }, jornada);
        }

        // DELETE api/Jornada/5
        [ResponseType(typeof(Jornada))]
        public async Task<IHttpActionResult> DeleteJornada(int id)
        {
            Jornada jornada = await db.Jornadas.FindAsync(id);
            if (jornada == null)
            {
                return NotFound();
            }

            db.Jornadas.Remove(jornada);
            await db.SaveChangesAsync();

            return Ok(jornada);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JornadaExists(int id)
        {
            return db.Jornadas.Count(e => e.id == id) > 0;
        }
    }
}