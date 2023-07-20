using Microsoft.EntityFrameworkCore;
using Vira.DataLayer.Entities.User;
using Vira.Web.Shared.Entities.Main;
using Vira.Web.Shared.Entities.permissions;
using Vira.Web.Shared.Entities.User;


namespace Vira.Web.Shared.Context
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
        public DbSet<VisitHomePage> VisitHomePages { get; set; }

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
