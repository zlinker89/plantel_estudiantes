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
    public class MatriculaController : ApiController
    {
        private plantel_estudiantesContext db = new plantel_estudiantesContext();

        // GET api/Matricula
        public IQueryable<Matricula> GetMatriculas()
        {
            return db.Matriculas;
        }

        // GET api/Matricula/5
        [ResponseType(typeof(Matricula))]
        public async Task<IHttpActionResult> GetMatricula(int id)
        {
            Matricula matricula = await db.Matriculas.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }

            return Ok(matricula);
        }

        // PUT api/Matricula/5
        public async Task<IHttpActionResult> PutMatricula(int id, Matricula matricula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != matricula.id)
            {
                return BadRequest();
            }

            db.Entry(matricula).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatriculaExists(id))
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

        // POST api/Matricula
        [ResponseType(typeof(Matricula))]
        public async Task<IHttpActionResult> PostMatricula(Matricula matricula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Matriculas.Add(matricula);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = matricula.id }, matricula);
        }

        // DELETE api/Matricula/5
        [ResponseType(typeof(Matricula))]
        public async Task<IHttpActionResult> DeleteMatricula(int id)
        {
            Matricula matricula = await db.Matriculas.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }

            db.Matriculas.Remove(matricula);
            await db.SaveChangesAsync();

            return Ok(matricula);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MatriculaExists(int id)
        {
            return db.Matriculas.Count(e => e.id == id) > 0;
        }
    }
}