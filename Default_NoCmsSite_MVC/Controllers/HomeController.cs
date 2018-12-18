using Default_NoCmsSite_MVC.Emails;
using Default_NoCmsSite_MVC.log4you;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Default_NoCmsSite_MVC.Controllers
{
  public class HomeController : BaseController
  {
    public HomeController(EmailHelper emailHelper)
    {

    }

    public ActionResult Index()
    {
      Log.Debug("Hello");

      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}