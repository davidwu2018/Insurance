using Insurance.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Data
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "Filename=./Insurance.sqlite");

        }

        public DbSet<ContentCategory> ContentCategory { get; set; }

        public DbSet<Content> Content { get; set; }

    }
}
