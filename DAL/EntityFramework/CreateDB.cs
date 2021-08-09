using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFramework
{
    class CreateDB: DbContext, IDb
    {
        public CreateDB() : base()
        {
        }
        IDbCollection<QRcode_data> IDb.QRDatas => new DbSetCollection<QRcode_data>(QRDatas);

        IDbCollection<Product> IDb.Products => new DbSetCollection<Product>(Products);

        IDbCollection<Category> IDb.Categories => new DbSetCollection<Category>(Categories);

        IDbCollection<Store> IDb.Stores => new DbSetCollection<Store>(Stores);

        IDbCollection<ShoppingCart> IDb.ShoppingCarts => new DbSetCollection<ShoppingCart>(ShoppingCarts);

        IDbCollection<ProductTransaction> IDb.ProductTransactions => new DbSetCollection<ProductTransaction>(ProductTransactions);

        IDbCollection<StoreGraph> IDb.StoreGraphs => new DbSetCollection<StoreGraph>(StoreGraphs);

        IDbCollection<ProductGraph> IDb.ProductGraphs => new DbSetCollection<ProductGraph>(ProductGraphs);

        IDbCollection<CategoryGraph> IDb.CategoryGraphs => new DbSetCollection<CategoryGraph>(CategoryGraphs);

        IDbCollection<ShoppingCartGraph> IDb.ShoppingCartGraphs => new DbSetCollection<ShoppingCartGraph>(ShoppingCartGraphs);

        IDbCollection<User> IDb.Users => new DbSetCollection<User>(Users);


        public DbSet<QRcode_data> QRDatas { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<ProductTransaction> ProductTransactions { get; set; }

        public DbSet<StoreGraph> StoreGraphs { get; set; }

        public DbSet<ProductGraph> ProductGraphs { get; set; }

        public DbSet<CategoryGraph> CategoryGraphs { get; set; }

        public DbSet<ShoppingCartGraph> ShoppingCartGraphs { get; set; }

        public DbSet<User> Users { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Id)
                .IsUnique();

            

            modelBuilder.Entity<Store>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<ProductGraph>()
                .HasMany<Product>(s => s.Products)
                .WithMany();

            modelBuilder.Entity<ProductGraph>()
                .HasIndex(p => p.Title)
                .IsUnique();

            modelBuilder.Entity<CategoryGraph>()
                .HasMany<Category>(s => s.Categories)
                .WithMany();

            modelBuilder.Entity<CategoryGraph>()
                .HasIndex(p => p.Title)
                .IsUnique();

            modelBuilder.Entity<StoreGraph>()
                .HasMany<Store>(s => s.Stores)
                .WithMany();

            modelBuilder.Entity<StoreGraph>()
               .HasIndex(p => p.Title)
               .IsUnique();

            modelBuilder.Entity<ShoppingCartGraph>()
               .HasIndex(p => p.Title)
               .IsUnique();
        }

           
        void IDb.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}

