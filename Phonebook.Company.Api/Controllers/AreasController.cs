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
    public class AreasController : ApiController
    {
        private dbPhonebookCompanyEntities db = new dbPhonebookCompanyEntities();

        // GET: api/Areas
        public IQueryable<Area> GetArea()
        {
            return db.Area;
        }

        // GET: api/Areas/5
        [ResponseType(typeof(Area))]
        public async Task<IHttpActionResult> GetArea(short id)
        {
            Area area = await db.Area.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            return Ok(area);
        }

        // PUT: api/Areas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArea(short id, Area area)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != area.IdArea)
            {
                return BadRequest();
            }

            db.Entry(area).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaExists(id))
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

        // POST: api/Areas
        [ResponseType(typeof(Area))]
        public async Task<IHttpActionResult> PostArea(Area area)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Area.Add(area);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = area.IdArea }, area);
        }

        // DELETE: api/Areas/5
        [ResponseType(typeof(Area))]
        public async Task<IHttpActionResult> DeleteArea(short id)
        {
            Area area = await db.Area.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            db.Area.Remove(area);
            await db.SaveChangesAsync();

            return Ok(area);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AreaExists(short id)
        {
            return db.Area.Count(e => e.IdArea == id) > 0;
        }
    }
}