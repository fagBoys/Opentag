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

        public DbSet<Order> Order { get; set; }
        public DbSet<Account> Account { get; set; }

        public DbSet<Article> Article { get; set; }

        public DbSet<Tag> Tag { get; set; }

        public DbSet<ArticleTag> ArticleTag { get; set; }

        public DbSet<Image> Image { get; set; }

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
