using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Vira.DataLayer.Entities.Main;
using vira.DataLayer.Entities.permissions;
using Vira.DataLayer.Entities.User;


namespace Vira.DataLayer.Context
{
    public class ViraContext : DbContext
    {

        public ViraContext(DbContextOptions<ViraContext> options) : base(options)
        {

        }



        #region User

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        #endregion

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<User>().HasQueryFilter(U => !U.IsDelete);


            base.OnModelCreating(modelBuilder);
        }
    }
}
