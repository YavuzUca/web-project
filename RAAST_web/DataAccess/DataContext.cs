using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAST_web.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RAAST_web.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Datacontext")
        {

        } 

        public DbSet<Editor> editors { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}