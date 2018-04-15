using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Core.Models;

namespace WebApi.Core.ApiDbContext
{
    public class StudentApiDbContext : DbContext
    {
        //public StudentApiDbContext() : base("StudentWebAPiDbContext")
        //{

        //}
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}