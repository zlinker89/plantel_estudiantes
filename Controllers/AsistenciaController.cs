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
    public class AsistenciaController : ApiController
    {
        private plantel_estudiantesContext db = new plantel_estudiantesContext();

        // GET api/Asistencia
        public IQueryable<Asistencia> GetAsistencias()
        {
            return db.Asistencias;
        }

        // GET api/Asistencia/5
        [ResponseType(typeof(Asistencia))]
        public async Task<IHttpActionResult> GetAsistencia(int id)
        {
            Asistencia asistencia = await db.Asistencias.FindAsync(id);
            if (asistencia == null)
            {
                return NotFound();
            }

            return Ok(asistencia);
        }

        // PUT api/Asistencia/5
        public async Task<IHttpActionResult> PutAsistencia(int id, Asistencia asistencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asistencia.id)
            {
                return BadRequest();
            }

            db.Entry(asistencia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsistenciaExists(id))
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

        // POST api/Asistencia
        [ResponseType(typeof(Asistencia))]
        public async Task<IHttpActionResult> PostAsistencia(Asistencia asistencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Asistencias.Add(asistencia);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = asistencia.id }, asistencia);
        }

        // DELETE api/Asistencia/5
        [ResponseType(typeof(Asistencia))]
        public async Task<IHttpActionResult> DeleteAsistencia(int id)
        {
            Asistencia asistencia = await db.Asistencias.FindAsync(id);
            if (asistencia == null)
            {
                return NotFound();
            }

            db.Asistencias.Remove(asistencia);
            await db.SaveChangesAsync();

            return Ok(asistencia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AsistenciaExists(int id)
        {
            return db.Asistencias.Count(e => e.id == id) > 0;
        }
    }
}