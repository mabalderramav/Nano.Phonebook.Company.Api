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
    public class CargosController : ApiController
    {
        private dbPhonebookCompanyEntities db = new dbPhonebookCompanyEntities();

        // GET: api/Cargos
        public IQueryable<Cargo> GetCargo()
        {
            return db.Cargo;
        }

        // GET: api/Cargos/5
        [ResponseType(typeof(Cargo))]
        public async Task<IHttpActionResult> GetCargo(short id)
        {
            Cargo cargo = await db.Cargo.FindAsync(id);
            if (cargo == null)
            {
                return NotFound();
            }

            return Ok(cargo);
        }

        // PUT: api/Cargos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCargo(short id, Cargo cargo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cargo.IdCargo)
            {
                return BadRequest();
            }

            db.Entry(cargo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoExists(id))
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

        // POST: api/Cargos
        [ResponseType(typeof(Cargo))]
        public async Task<IHttpActionResult> PostCargo(Cargo cargo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cargo.Add(cargo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cargo.IdCargo }, cargo);
        }

        // DELETE: api/Cargos/5
        [ResponseType(typeof(Cargo))]
        public async Task<IHttpActionResult> DeleteCargo(short id)
        {
            Cargo cargo = await db.Cargo.FindAsync(id);
            if (cargo == null)
            {
                return NotFound();
            }

            db.Cargo.Remove(cargo);
            await db.SaveChangesAsync();

            return Ok(cargo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CargoExists(short id)
        {
            return db.Cargo.Count(e => e.IdCargo == id) > 0;
        }
    }
}