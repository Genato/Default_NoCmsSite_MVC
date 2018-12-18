using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Web;
using System.Web.Mvc;
using Default_NoCmsSite_MVC.Controllers;
using Default_NoCmsSite_MVC.Emails;

namespace Default_NoCmsSite_MVC.App_Start
{
  public class ConfigureDI
  {
    public static void ConfigureDependencyInjection()
    {
      // We will use Dependency Injection for all controllers and other classes, so we'll need a service collection
      ServiceCollection services = new ServiceCollection();

      // configure all of the services required for DI
      ConfigureServices(services);

      // Create a new resolver from our own default implementation
      CustomDependencyResolver resolver = new CustomDependencyResolver(services.BuildServiceProvider());

      // Set the application resolver to our default resolver. This comes from "System.Web.Mvc"
      //Other services may be added elsewhere through time
      DependencyResolver.SetResolver(resolver);
    }

    private static void ConfigureServices(IServiceCollection services)
    {

      ////////////////////////////////////////////////////////////////////////////////////////////////////////
      /// Add classes to DI - Start
      ////////////////////////////////////////////////////////////////////////////////////////////////////////
      
      services.AddTransient(typeof(EmailHelper));

      ////////////////////////////////////////////////////////////////////////////////////////////////////////
      /// Add ONTO to DI - Start - End
      ////////////////////////////////////////////////////////////////////////////////////////////////////////

      // Add Controllers to DI(Dependency Injection)
      services.AddControllersAsServices(typeof(MvcApplication).Assembly.GetExportedTypes()
         .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
         .Where(t => typeof(IController).IsAssignableFrom(t) || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));
    }
  }

  internal class CustomDependencyResolver : IDependencyResolver
  {
    protected IServiceProvider _serviceProvider;

    public CustomDependencyResolver(IServiceProvider serviceProvider)
    {
      _serviceProvider = serviceProvider;
    }

    public object GetService(Type serviceType)
    {
      return this._serviceProvider.GetService(serviceType);
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
      return this._serviceProvider.GetServices(serviceType);
    }
  }

  public static class ServiceProviderExtensions
  {
    public static IServiceCollection AddControllersAsServices(this IServiceCollection services, IEnumerable<Type> controllerTypes)
    {
      foreach (var type in controllerTypes)
      {
        services.AddTransient(type);
      }

      return services;
    }
  }
}