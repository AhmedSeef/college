using AutoMapper;
using college.APIWEB.Mapper;
using college.BL.Contract;
using college.BL.Contract.Base;
using college.BL.Implementation;
using college.BL.Implementation.Base;
using college.BL.SartUp;
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
            InjectBL.RegisterComponents(container);

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = configuration.CreateMapper();
            container.RegisterInstance(mapper);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}