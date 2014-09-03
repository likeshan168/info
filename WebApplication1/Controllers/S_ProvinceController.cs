using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class S_ProvinceController : Controller
    {
        private areaEntities db = new areaEntities();

        // GET: S_Province
        public async Task<ActionResult> Index()
        {
            return View(await db.S_Province.ToListAsync());
        }

        // GET: S_Province/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            S_Province s_Province = await db.S_Province.FindAsync(id);
            
            if (s_Province == null)
            {
                return HttpNotFound();
            }
            return View(s_Province);
        }

        // GET: S_Province/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: S_Province/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProvinceID,ProvinceName")] S_Province s_Province)
        {
            if (ModelState.IsValid)
            {
                s_Province.DateCreated = DateTime.Now;
                s_Province.DateUpdated = DateTime.Now;

                db.S_Province.Add(s_Province);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(s_Province);
        }

        // GET: S_Province/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            S_Province s_Province = await db.S_Province.FindAsync(id);
            if (s_Province == null)
            {
                return HttpNotFound();
            }
            return View(s_Province);
        }

        // POST: S_Province/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProvinceID,ProvinceName")] S_Province s_Province)
        {
            if (ModelState.IsValid)
            {
                s_Province.DateUpdated = DateTime.Now;
                db.Entry(s_Province).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(s_Province);
        }

        // GET: S_Province/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            S_Province s_Province = await db.S_Province.FindAsync(id);
            if (s_Province == null)
            {
                return HttpNotFound();
            }
            return View(s_Province);
        }

        // POST: S_Province/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            S_Province s_Province = await db.S_Province.FindAsync(id);
            db.S_Province.Remove(s_Province);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
