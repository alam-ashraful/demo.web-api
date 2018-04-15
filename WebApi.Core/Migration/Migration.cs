using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebApi.Core.ApiDbContext;

namespace WebApi.Core.Migration
{
    internal sealed class Migration : DbMigrationsConfiguration<StudentApiDbContext>
    {
        public Migration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(StudentApiDbContext context)
        {
            //base.Seed(context);
        }
    }
}