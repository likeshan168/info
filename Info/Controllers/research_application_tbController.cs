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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Info;
using Info.Models;

namespace Info.Controllers
{
    /*
    在为此控制器添加路由之前，WebApiConfig 类可能要求你做出其他更改。请适当地将这些语句合并到 WebApiConfig 类的 Register 方法中。请注意 OData URL 区分大小写。

    using System.Web.Http.OData.Builder;
    using Info;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<infos>("infos");
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class infosController : ODataController
    {
        private cosenEntities db = new cosenEntities();

        // GET: odata/infos
        [Queryable]
        public IQueryable<research_application_tb> Getinfos()
        {
            return db.infos;
        }

        // GET: odata/infos(5)
        [Queryable]
        public SingleResult<research_application_tb> Getinfos([FromODataUri] long key)
        {
            return SingleResult.Create(db.infos.Where(infos => infos.Id == key));
        }

        // PUT: odata/infos(5)
        public async Task<IHttpActionResult> Put([FromODataUri] long key, research_application_tb infos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != infos.Id)
            {
                return BadRequest();
            }

            db.Entry(infos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!infosExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(infos);
        }

        // POST: odata/infos
        public async Task<IHttpActionResult> Post(research_application_tb infos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.infos.Add(infos);
            await db.SaveChangesAsync();

            return Created(infos);
        }

        // PATCH: odata/infos(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] long key, Delta<research_application_tb> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            research_application_tb infos = await db.infos.FindAsync(key);
            if (infos == null)
            {
                return NotFound();
            }

            patch.Patch(infos);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!infosExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(infos);
        }

        // DELETE: odata/infos(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] long key)
        {
            research_application_tb infos = await db.infos.FindAsync(key);
            if (infos == null)
            {
                return NotFound();
            }

            db.infos.Remove(infos);
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

        private bool infosExists(long key)
        {
            return db.infos.Count(e => e.Id == key) > 0;
        }
    }
}
