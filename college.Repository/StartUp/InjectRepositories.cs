using college.Repository.Contract;
using college.Repository.Contract.Base;
using college.Repository.Implementation;
using college.Repository.Implementation.Base;
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
            container.RegisterType<IUnitOfWork, UnitOfWork>();           
        }
    }
}
