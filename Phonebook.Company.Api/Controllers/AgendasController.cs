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
    public class AgendasController : ApiController
    {
        private dbPhonebookCompanyEntities db = new dbPhonebookCompanyEntities();

        // GET: api/Agenda
        public IQueryable<Agenda> GetAgenda()
        {
            return db.Agenda;
        }

        // GET: api/Agenda/5
        [ResponseType(typeof(Agenda))]
        public async Task<IHttpActionResult> GetAgenda(int id)
        {
            Agenda agenda = await db.Agenda.FindAsync(id);
            if (agenda == null)
            {
                return NotFound();
            }

            return Ok(agenda);
        }

        // PUT: api/Agenda/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAgenda(int id, Agenda agenda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agenda.IdAgenda)
            {
                return BadRequest();
            }

            db.Entry(agenda).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendaExists(id))
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

        // POST: api/Agenda
        [ResponseType(typeof(Agenda))]
        public async Task<IHttpActionResult> PostAgenda(Agenda agenda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Agenda.Add(agenda);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = agenda.IdAgenda }, agenda);
        }

        // DELETE: api/Agenda/5
        [ResponseType(typeof(Agenda))]
        public async Task<IHttpActionResult> DeleteAgenda(int id)
        {
            Agenda agenda = await db.Agenda.FindAsync(id);
            if (agenda == null)
            {
                return NotFound();
            }

            db.Agenda.Remove(agenda);
            await db.SaveChangesAsync();

            return Ok(agenda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgendaExists(int id)
        {
            return db.Agenda.Count(e => e.IdAgenda == id) > 0;
        }
    }
}