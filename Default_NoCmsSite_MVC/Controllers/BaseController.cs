using Default_NoCmsSite_MVC.log4you;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Default_NoCmsSite_MVC.Controllers
{
  /// <summary>
  /// Bazni kontroler kojeg nasljeđuju svi kontroleri ove aplikacije
  /// </summary>
  public class BaseController : Controller
  {
    /// <summary>
    /// Exception handling.
    /// </summary>
    /// <param name="filterContext"></param>
    protected override void OnException(ExceptionContext filterContext)
    {
      

      base.OnException(filterContext);
    }
  }
}