using college.Repository.Contract;
using college.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace college.Repository.StartUp
{
    public class InjectRepositories
    {
        public static void RegisterComponents(UnityContainer container)
        {           
            container.RegisterType<IUserRepository, UserRepository>();           
        }
    }
}
