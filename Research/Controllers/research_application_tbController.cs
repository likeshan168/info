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
using Research;
//using System.Web.Http.OData;
using System.Web.OData;
using System.Threading.Tasks;

namespace Research.Controllers
{
    public class research_application_tbController : ODataController
    {
        private cosenEntities db = new cosenEntities();

        // GET: api/research_application_tb
        [EnableQuery]
        public IQueryable<research_application_tb> Getresearch_application_tb()
        {
            return db.research_application_tb;
        }
        #region 
        
        
        //// GET: api/research_application_tb/5
        //[ResponseType(typeof(research_application_tb))]
        //public IHttpActionResult Getresearch_application_tb(long id)
        //{
        //    research_application_tb research_application_tb = db.research_application_tb.Find(id);
        //    if (research_application_tb == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(research_application_tb);
        //}

        //// PUT: api/research_application_tb/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult Putresearch_application_tb(long id, research_application_tb research_application_tb)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != research_application_tb.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(research_application_tb).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!research_application_tbExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/research_application_tb
        //[ResponseType(typeof(research_application_tb))]
        //public IHttpActionResult Postresearch_application_tb(research_application_tb research_application_tb)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.research_application_tb.Add(research_application_tb);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = research_application_tb.Id }, research_application_tb);
        //}

        //// DELETE: api/research_application_tb/5
        //[ResponseType(typeof(research_application_tb))]
        //public IHttpActionResult Deleteresearch_application_tb(long id)
        //{
        //    research_application_tb research_application_tb = db.research_application_tb.Find(id);
        //    if (research_application_tb == null)
        //    {
        //        return NotFound();
        //    }

        //    db.research_application_tb.Remove(research_application_tb);
        //    db.SaveChanges();

        //    return Ok(research_application_tb);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool research_application_tbExists(long id)
        //{
        //    return db.research_application_tb.Count(e => e.Id == id) > 0;
        //}

        #endregion


        // GET odata/Products(5)
        [EnableQuery]
        public SingleResult<research_application_tb> GetProduct([FromODataUri] int key)
        {
            return SingleResult.Create(db.research_application_tb.Where(product => product.Id == key));
        }

        // PUT odata/Products(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, research_application_tb product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != product.Id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(product);
        }

        // POST odata/Products
        public async Task<IHttpActionResult> Post(research_application_tb product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.research_application_tb.Add(product);
            await db.SaveChangesAsync();

            return Created(product);
        }

        // PATCH odata/Products(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<research_application_tb> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            research_application_tb product = await db.research_application_tb.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }

            patch.Patch(product);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(product);
        }

        // DELETE odata/Products(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            research_application_tb product = await db.research_application_tb.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }

            db.research_application_tb.Remove(product);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int key)
        {
            return db.research_application_tb.Count(e => e.Id == key) > 0;
        }
    }
}