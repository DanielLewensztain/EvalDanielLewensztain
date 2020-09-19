using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EvalDanielLewensztain.Models;

namespace EvalDanielLewensztain.Controllers
{
    public class LewensztainsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Lewensztains
        [Authorize]
        public IQueryable<Lewensztain> GetLewensztains()
        {
            return db.Lewensztains;
        }

        // GET: api/Lewensztains/5
        [Authorize]
        [ResponseType(typeof(Lewensztain))]
        public IHttpActionResult GetLewensztain(string id)
        {
            Lewensztain lewensztain = db.Lewensztains.Find(id);
            if (lewensztain == null)
            {
                return NotFound();
            }

            return Ok(lewensztain);
        }

        // PUT: api/Lewensztains/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLewensztain(string id, Lewensztain lewensztain)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lewensztain.Pais)
            {
                return BadRequest();
            }

            db.Entry(lewensztain).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LewensztainExists(id))
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

        // POST: api/Lewensztains
        [Authorize]
        [ResponseType(typeof(Lewensztain))]
        public IHttpActionResult PostLewensztain(Lewensztain lewensztain)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lewensztains.Add(lewensztain);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LewensztainExists(lewensztain.Pais))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = lewensztain.Pais }, lewensztain);
        }

        // DELETE: api/Lewensztains/5
        [Authorize]
        [ResponseType(typeof(Lewensztain))]
        public IHttpActionResult DeleteLewensztain(string id)
        {
            Lewensztain lewensztain = db.Lewensztains.Find(id);
            if (lewensztain == null)
            {
                return NotFound();
            }

            db.Lewensztains.Remove(lewensztain);
            db.SaveChanges();

            return Ok(lewensztain);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LewensztainExists(string id)
        {
            return db.Lewensztains.Count(e => e.Pais == id) > 0;
        }
    }
}