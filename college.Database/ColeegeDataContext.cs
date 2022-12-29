using college.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.Database
{
    public class ColeegeDataContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
    }
}
