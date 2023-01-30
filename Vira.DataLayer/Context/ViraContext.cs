using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vira.DataLayer.Entities.Article;
using Vira.DataLayer.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Vira.DataLayer.Entities.User;
using Vira.DataLayer.Entities.permissions;
using Vira.DataLayer.Entities.Product;
using Vira.DataLayer.Entities.Storage;
using Vira.DataLayer.Entities.Cart;
using Vira.DataLayer.Entities.Notification;
using Vira.DataLayer.Entities.payment;
using Vira.DataLayer.Entities.ProductReturn;
using Vira.DataLayer.Entities.Slider;
using Vira.DataLayer.Entities.Support;



namespace Vira.DataLayer.Context
{
    public class ViraContext : DbContext
    {

        public ViraContext(DbContextOptions<ViraContext> options) : base(options)
        {

        }


        #region User

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserDiscountCode> UserDiscountCodes { get; set; }
        public DbSet<VisiteCount> VisiteCounts { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }

        #endregion

        #region Permission

        public DbSet<permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }

        #endregion

        #region Product

        public DbSet<Product> Products { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Attribut> Attributs { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<AnswerComment> AnswerComments { get; set; }
        public DbSet<ProductCommnetLike>  ProductCommnetLikes{ get; set; }


        //public DbSet<GroupAttribut> GroupAttributs { get; set; }



        #endregion

        #region Storage

        public DbSet<Storage> Storages { get; set; }

        #endregion

        #region Order


        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        #endregion

        #region Cart

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        #endregion

        #region Wallet

        //public DbSet<WalletType> WalletTypes { get; set; }
        //public DbSet<Wallet> Wallets { get; set; }

        //#endregion

        //#region Permission

        //public DbSet<permission> Permission { get; set; }
        //public DbSet<RolePermission> RolePermission { get; set; }

        //#endregion

        //#region Product

        //public DbSet<Product> Products { get; set; }
        //public DbSet<ProductGroup> ProductGroups { get; set; }
        //public DbSet<UserProduct> UserProducts { get; set; }
        //public DbSet<ProductComment> ProductComments { get; set; }
        //public DbSet<ProductVote> ProductVotes { get; set; }


        //#endregion

        //#region Order

        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderDetail> OrdersDetails { get; set; }
        //public DbSet<Discount> Discounts { get; set; }

        //#endregion

        //#region Question

        //public DbSet<Question> Questions { get; set; }
        //public DbSet<Answer> Answers { get; set; }

        #endregion

        #region Payment

        public DbSet<RequestPay> RequestPays { get; set; }


        #endregion

        #region Like
        public DbSet<Like> Likes { get; set; }
        #endregion

        #region Article
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleComment> ArticleComments { get; set; }
        public DbSet<ArticleAnswerComment> ArticleAnswerComments { get; set; }
        public DbSet<ArticleCommentLike> ArticleCommentLikes { get; set; }
        #endregion

        #region Notification
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ArticleNotification> ArticleNotifications { get; set; }
        #endregion

        #region MessengerSupport

        public DbSet<MessengerSupport> MessengerSupports { get; set; }

        #endregion

        #region Slider
        public DbSet<Slider> Sliders{ get; set; }

        #endregion

        #region Vote

        public DbSet<Vote> Votes { get; set; }

        #endregion

        #region ProductReturn

        public DbSet<ProductReturn> ProductReturns { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<User>().HasQueryFilter(U => !U.IsDelete);
            modelBuilder.Entity<Role>().HasQueryFilter(R => !R.IsDelete);
            modelBuilder.Entity<ProductGroup>().HasQueryFilter(G => !G.IsDelete);
            modelBuilder.Entity<Storage>().HasQueryFilter(G => !G.IsDelete);
            modelBuilder.Entity<Cart>().HasQueryFilter(G => !G.IsDelete);
            modelBuilder.Entity<CartItem>().HasQueryFilter(G => !G.IsDelete);
            modelBuilder.Entity<ProductComment>().HasQueryFilter(G => !G.IsDelete);
            modelBuilder.Entity<ArticleComment>().HasQueryFilter(G => !G.IsDelete);


            modelBuilder.Entity<Product>()
                .HasOne<ProductGroup>(f => f.ProductGroup)
                .WithMany(g => g.Products)
                .HasForeignKey(f => f.GroupId);

            modelBuilder.Entity<Product>()
                .HasOne<ProductGroup>(f => f.Group)
                .WithMany(g => g.SubGroup)
                .HasForeignKey(f => f.SubGroup);




            base.OnModelCreating(modelBuilder);
        }
    }
}
