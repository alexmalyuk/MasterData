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
using MD.Data.Models;

namespace MasterData.Contollers_api
{
    public class ContractorsController : ApiController
    {
        private MdContext db = new MdContext();

        // GET: api/Contractors
        public IQueryable<Contractor> GetContractorSet()
        {
            return db.ContractorSet;
        }

        // GET: api/Contractors/5
        [ResponseType(typeof(Contractor))]
        public async Task<IHttpActionResult> GetContractor(Guid id)
        {
            Contractor contractor = await db.ContractorSet.FindAsync(id);
            if (contractor == null)
            {
                return NotFound();
            }

            return Ok(contractor);
        }

        // PUT: api/Contractors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContractor(Guid id, Contractor contractor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contractor.Id)
            {
                return BadRequest();
            }

            db.Entry(contractor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractorExists(id))
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

        // POST: api/Contractors
        [ResponseType(typeof(Contractor))]
        public async Task<IHttpActionResult> PostContractor(Contractor contractor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContractorSet.Add(contractor);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContractorExists(contractor.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = contractor.Id }, contractor);
        }

        // DELETE: api/Contractors/5
        [ResponseType(typeof(Contractor))]
        public async Task<IHttpActionResult> DeleteContractor(Guid id)
        {
            Contractor contractor = await db.ContractorSet.FindAsync(id);
            if (contractor == null)
            {
                return NotFound();
            }

            db.ContractorSet.Remove(contractor);
            await db.SaveChangesAsync();

            return Ok(contractor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContractorExists(Guid id)
        {
            return db.ContractorSet.Count(e => e.Id == id) > 0;
        }
    }
}