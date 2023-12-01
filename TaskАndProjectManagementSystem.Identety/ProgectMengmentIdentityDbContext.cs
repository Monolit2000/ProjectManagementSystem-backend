using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskАndProjectManagementSystem.Domain;

namespace TaskАndProjectManagementSystem.Identety
{
    public class ProgectMengmentIdentityDbContext : IdentityDbContext<User>
    {

        public ProgectMengmentIdentityDbContext(DbContextOptions<ProgectMengmentIdentityDbContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
