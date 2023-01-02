using college.Database.Mapping;
using college.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace college.Database
{
    public class ColeegeDataContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
            .HasMany(t => t.Subjects)
            .WithMany(t => t.Students)
            .Map(m =>
            {
                m.ToTable("StudentSubjects");
                m.MapLeftKey("StudentID");
                m.MapRightKey("SubjecteID");
            });

            modelBuilder.Configurations.Add(new SubjectMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
