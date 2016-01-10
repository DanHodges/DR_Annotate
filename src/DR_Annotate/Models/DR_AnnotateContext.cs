using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace DR_Annotate.Models
{
    public class DR_AnnotateContext : DbContext
    {
        public DR_AnnotateContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Annotation> Annotations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:DR_AnnotateContextConnection"];
            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
