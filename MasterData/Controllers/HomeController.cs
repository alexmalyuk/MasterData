using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterData.Contollers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            Log.For(this).Debug("Debug - HomeController-Index()");
            Log.For(this).Error("Error - HomeController-Index()");

            try
            {
                object d = null;
                d.ToString();
            }

            catch (Exception ex)
            {
                Log.For(this).Error("Err..", ex);
            }

            return View();
        }
    }
}
