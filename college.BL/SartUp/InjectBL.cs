using college.Repository.Contract.Base;
using college.Repository.Contract;
using college.Repository.Implementation.Base;
using college.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using college.BL.Contract;
using college.BL.Implementation;
using college.Repository.StartUp;

namespace college.BL.SartUp
{
    public class InjectBL
    {
        public static void RegisterComponents(UnityContainer container)
        {
            InjectRepositories.RegisterComponents(container);           
            container.RegisterType<IUserBL, UserBL>();  
        }
    }
}
