using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Info;
using Info.Models;
using System.IO;
using System.Drawing;

namespace Info.Controllers
{
    public class InfoController : Controller
    {
        private cosenEntities db = new cosenEntities();
        [CompressFilter(Order = 1)]
        [OutputCache(CacheProfile = "info", SqlDependency = "myDependency:research_application_tb")]//cachename+表名 加在control方法头上.多表需要成对出现,以分号分隔.
        // GET: Info
        public async Task<ActionResult> Index()
        {
            HttpContext.Cache["page"] = 1;
            return View(await db.infos.Take(8).OrderBy(p => p.Province).ToListAsync());


        }
     
        [CompressFilter(Order = 1)]
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            research_application_tb infos = await db.infos.FindAsync(id);
            if (infos == null)
            {
                return HttpNotFound();
            }
            return View(infos);
        }

        // GET: Info/Create
        [CompressFilter(Order = 1)]
        [OutputCache(CacheProfile = "info")]

        public ActionResult Create()
        {
            return View();
        }

        // POST: Info/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create([Bind(Include = "Id,CustomerName,ContactPerson,ContactPhone,Province,City,CompanyAddress,ImageFile,BCompany")] CreateInfo createInfo)
        {
            if (ModelState.IsValid)
            {
                research_application_tb res = new research_application_tb();
                res.CustomerName = createInfo.CustomerName;
                res.ContactPerson = createInfo.ContactPerson;
                res.ContactPhone = createInfo.ContactPhone;
                res.CompanyAddress = createInfo.CompanyAddress;
                res.Province = createInfo.Province;
                res.City = createInfo.City;
                res.Remark = createInfo.Remark;
                res.BCompany = createInfo.BCompany;

                if (createInfo.ImageFile != null)
                {
                    res.ImageType = createInfo.ImageFile.ContentType;
                    res.Image = new byte[createInfo.ImageFile.ContentLength];
                    createInfo.ImageFile.InputStream.Read(res.Image, 0, createInfo.ImageFile.ContentLength);
                }
                db.infos.Add(res);

                await db.SaveChangesAsync();
                return RedirectToAction("Details", new { res.Id });
            }

            return View(createInfo);
        }
        /// <summary>
        ///显示原始图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OutputCache(CacheProfile = "id")]
        [CompressFilter(Order = 1)]
        public ActionResult GetImage(long id)
        {
            research_application_tb res = db.infos.FirstOrDefault(p => p.Id == id);
            if (res != null)
            {

                //return File(res.Image, res.ImageType);
                MemoryStream stream = new MemoryStream(res.Image);
                System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                Bitmap bit = new Bitmap(image, 1200, 1400);
                ImageResult result = new ImageResult(bit, System.Drawing.Imaging.ImageFormat.Jpeg);
                return result;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 显示小图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OutputCache(CacheProfile = "id")]//根据参数进行缓存
        [CompressFilter(Order = 1)]//进行压缩
        public ActionResult GetSmallImage(long id)
        {
            research_application_tb res = db.infos.FirstOrDefault(p => p.Id == id);
            if (res != null)
            {

                MemoryStream stream = new MemoryStream(res.Image);
                System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                Bitmap bit = new Bitmap(image, 40, 40);
                ImageResult result = new ImageResult(bit, System.Drawing.Imaging.ImageFormat.Jpeg);
                return result;
                //return File(res.Image, res.ImageType);
            }
            else
            {
                return null;
            }
        }

        // GET: Info/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            research_application_tb infos = await db.infos.FindAsync(id);
            CreateInfo res = new CreateInfo();

            res.Id = infos.Id;
            res.CustomerName = infos.CustomerName;
            res.ContactPerson = infos.ContactPerson;
            res.ContactPhone = infos.ContactPhone;

            res.CompanyAddress = infos.CompanyAddress;
            res.Province = infos.Province;
            res.City = infos.City;
            res.Image = infos.Image;
            res.Remark = infos.Remark;
            res.BCompany = infos.BCompany;
            if (res == null)
            {
                return HttpNotFound();
            }
            //缓存起来
            HttpContext.Cache["editinfo"] = infos;

            return View(res);
        }

        // POST: Info/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit([Bind(Include = "Id,CustomerName,ContactPerson,ContactPhone,Province,City,CompanyAddress,Remark,ImageFile,BCompany")] CreateInfo infos)
        {
            if (ModelState.IsValid)
            {
                research_application_tb res = (research_application_tb)HttpContext.Cache["editinfo"];
                db.infos.Attach(res);

                res.Id = infos.Id;
                res.CustomerName = infos.CustomerName;
                res.ContactPerson = infos.ContactPerson;
                res.ContactPhone = infos.ContactPhone;

                res.CompanyAddress = infos.CompanyAddress;
                res.Province = infos.Province;
                res.City = infos.City;
                res.Remark = infos.Remark;
                res.BCompany = infos.BCompany;



                if (infos.ImageFile != null)
                {
                    res.ImageType = infos.ImageFile.ContentType;
                    res.Image = new byte[infos.ImageFile.ContentLength];

                    infos.ImageFile.InputStream.Read(res.Image, 0, infos.ImageFile.ContentLength);
                }

                


                //db.Entry(res).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Details", new { res.Id });
            }
            return View(infos);
        }

        // GET: Info/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            research_application_tb infos = await db.infos.FindAsync(id);
            if (infos == null)
            {
                return HttpNotFound();
            }
            return View(infos);
        }

        // POST: Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            research_application_tb infos = await db.infos.FindAsync(id);
            db.infos.Remove(infos);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CompressFilter(Order = 1)]
        //[OutputCache(CacheProfile = "phoneNo")]
        public async Task<ActionResult> Search(string cond, string phoneNo)
        {

            HttpContext.Cache["page"] = 1;
            if (cond == "1")//手机号码
            {
                if (!string.IsNullOrEmpty(phoneNo))
                    return PartialView("_InfoPartial", await db.infos.Where(p => p.ContactPhone.StartsWith(phoneNo)).OrderBy(p => p.Province).ToListAsync());
                else
                    return null;
            }
            else if (cond == "2")//省份
            {
                if (!string.IsNullOrEmpty(phoneNo))
                    return PartialView("_InfoPartial", await db.infos.Where(p => p.Province.StartsWith(phoneNo)).OrderBy(p => p.Province).ToListAsync());
                else
                    return null;
            }
            else//业务负责人
            {
                if (!string.IsNullOrEmpty(phoneNo))
                    return PartialView("_InfoPartial", await db.infos.Where(p => p.BCompany.StartsWith(phoneNo)).OrderBy(p => p.Province).ToListAsync());
                else
                    return null;
            }


        }

        [HttpPost]
        [CompressFilter(Order = 1)]
        [OutputCache(CacheProfile = "id", SqlDependency = "myDependency:research_application_tb")]
        public ActionResult GetInfoByPage(int id)
        {
            HttpContext.Cache["page"] = id;
            return PartialView("_InfoPartial", db.infos.OrderBy(p => p.Province).Skip((id - 1) * 8).Take(8).ToList());
        }

        [HttpPost]
        public string DelImage(long id)
        {
            research_application_tb res = (research_application_tb)HttpContext.Cache["editinfo"];
            db.infos.Attach(res);
            res.Image = null;
            db.SaveChanges();
            return "";
        }
    }
}
