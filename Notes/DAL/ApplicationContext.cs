using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Notes.Models;

namespace Notes.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("ApplicationContext")
        {

        }

        public DbSet<Directory> Directories { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
