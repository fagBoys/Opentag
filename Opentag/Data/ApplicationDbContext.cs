using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Opentag.Models;
using Microsoft.Extensions.Configuration;

namespace Opentag.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Contact> Contact { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=185.192.112.82;Database=DB01Opentag;User Id=fagboys;Password=OPENpass123");

            optionsBuilder.UseSqlServer("Server =.; Database = DB01Opentag; Trusted_Connection = True; MultipleActiveResultSets = true");

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
