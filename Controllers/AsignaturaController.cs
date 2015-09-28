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
    public class AsignaturaController : ApiController
    {
        private plantel_estudiantesContext db = new plantel_estudiantesContext();

        // GET api/Asignatura
        public IQueryable<Asignatura> GetAsignaturas()
        {
            return db.Asignaturas;
        }

        // GET api/Asignatura/5
        [ResponseType(typeof(Asignatura))]
        public async Task<IHttpActionResult> GetAsignatura(int id)
        {
            Asignatura asignatura = await db.Asignaturas.FindAsync(id);
            if (asignatura == null)
            {
                return NotFound();
            }

            return Ok(asignatura);
        }

        // PUT api/Asignatura/5
        public async Task<IHttpActionResult> PutAsignatura(int id, Asignatura asignatura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asignatura.id)
            {
                return BadRequest();
            }

            db.Entry(asignatura).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignaturaExists(id))
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

        // POST api/Asignatura
        [ResponseType(typeof(Asignatura))]
        public async Task<IHttpActionResult> PostAsignatura(Asignatura asignatura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Asignaturas.Add(asignatura);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = asignatura.id }, asignatura);
        }

        // DELETE api/Asignatura/5
        [ResponseType(typeof(Asignatura))]
        public async Task<IHttpActionResult> DeleteAsignatura(int id)
        {
            Asignatura asignatura = await db.Asignaturas.FindAsync(id);
            if (asignatura == null)
            {
                return NotFound();
            }

            db.Asignaturas.Remove(asignatura);
            await db.SaveChangesAsync();

            return Ok(asignatura);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AsignaturaExists(int id)
        {
            return db.Asignaturas.Count(e => e.id == id) > 0;
        }
    }
}