using college.Repository.Contract;
using college.Repository.Implementation;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace college.Repository
{
    public static class UnityConfig
    {
        public static void RegisterComponents(UnityContainer container)
        {
            container.RegisterType<IUserRepository, UserRepository>();
        }
    }
}