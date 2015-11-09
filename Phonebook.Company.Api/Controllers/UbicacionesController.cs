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
using Nano.Phonebook.Company.Api.Models;

namespace Nano.Phonebook.Company.Api.Controllers
{
    public class UbicacionesController : ApiController
    {
        private dbPhonebookCompanyEntities db = new dbPhonebookCompanyEntities();

        // GET: api/Ubicaciones
        public IQueryable<Ubicacion> GetUbicacion()
        {
            return db.Ubicacion;
        }

        // GET: api/Ubicaciones/5
        [ResponseType(typeof(Ubicacion))]
        public async Task<IHttpActionResult> GetUbicacion(short id)
        {
            Ubicacion ubicacion = await db.Ubicacion.FindAsync(id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            return Ok(ubicacion);
        }

        // PUT: api/Ubicaciones/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUbicacion(short id, Ubicacion ubicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ubicacion.IdUbicacion)
            {
                return BadRequest();
            }

            db.Entry(ubicacion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UbicacionExists(id))
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

        // POST: api/Ubicaciones
        [ResponseType(typeof(Ubicacion))]
        public async Task<IHttpActionResult> PostUbicacion(Ubicacion ubicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ubicacion.Add(ubicacion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ubicacion.IdUbicacion }, ubicacion);
        }

        // DELETE: api/Ubicaciones/5
        [ResponseType(typeof(Ubicacion))]
        public async Task<IHttpActionResult> DeleteUbicacion(short id)
        {
            Ubicacion ubicacion = await db.Ubicacion.FindAsync(id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            db.Ubicacion.Remove(ubicacion);
            await db.SaveChangesAsync();

            return Ok(ubicacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UbicacionExists(short id)
        {
            return db.Ubicacion.Count(e => e.IdUbicacion == id) > 0;
        }
    }
}