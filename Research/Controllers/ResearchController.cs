using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Research.Controllers
{
    public class ResearchController : Controller
    {
        // GET: Research
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult info()
        {
            return View();
        }
    }
}