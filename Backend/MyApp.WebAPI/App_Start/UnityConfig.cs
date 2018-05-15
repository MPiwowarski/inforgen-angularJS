using MyApp.SqlServerModel;
using MyApp.SqlServerModel.Repositories;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.WebApi;

namespace MyApp.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<MyAppDbContext>(new InjectionFactory(c => { return MyAppDbContext.Create(); }));
            container.RegisterType<IAddressRepo, AddressRepo>();
            container.RegisterType<IContactRepo, ContactRepo>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            
        }
    }
}