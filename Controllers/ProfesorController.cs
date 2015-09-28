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
    public class ProfesorController : ApiController
    {
        private plantel_estudiantesContext db = new plantel_estudiantesContext();

        // GET api/Profesor
        public IQueryable<Profesor> GetProfesors()
        {
            return db.Profesors;
        }

        // GET api/Profesor/5
        [ResponseType(typeof(Profesor))]
        public async Task<IHttpActionResult> GetProfesor(int id)
        {
            Profesor profesor = await db.Profesors.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }

            return Ok(profesor);
        }

        // PUT api/Profesor/5
        public async Task<IHttpActionResult> PutProfesor(int id, Profesor profesor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profesor.id)
            {
                return BadRequest();
            }

            db.Entry(profesor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesorExists(id))
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

        // POST api/Profesor
        [ResponseType(typeof(Profesor))]
        public async Task<IHttpActionResult> PostProfesor(Profesor profesor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profesors.Add(profesor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = profesor.id }, profesor);
        }

        // DELETE api/Profesor/5
        [ResponseType(typeof(Profesor))]
        public async Task<IHttpActionResult> DeleteProfesor(int id)
        {
            Profesor profesor = await db.Profesors.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }

            db.Profesors.Remove(profesor);
            await db.SaveChangesAsync();

            return Ok(profesor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfesorExists(int id)
        {
            return db.Profesors.Count(e => e.id == id) > 0;
        }
    }
}