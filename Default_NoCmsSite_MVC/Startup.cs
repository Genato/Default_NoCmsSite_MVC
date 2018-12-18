using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Default_NoCmsSite_MVC.Startup))]

namespace Default_NoCmsSite_MVC
{
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
    }
  }
}
