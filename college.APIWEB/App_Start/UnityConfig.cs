using college.Repository.Contract;
using college.Repository.Implementation;
using college.Repository.StartUp;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace college.APIWEB
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            // container.RegisterType<IUserRepository, UserRepository>();
            InjectRepositories.RegisterComponents(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}