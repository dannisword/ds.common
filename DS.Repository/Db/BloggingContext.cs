using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

using DS.Common.Entities;
using DS.Common.Models;

namespace DS.Repository.Db
{
    public class BloggingContext : DbContext
    {
        //public virtual DbSet<Blog> Blog { get; set; }
        //public virtual DbSet<Post> Post { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public BloggingContext() : base()
        {
        }

        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");


            /*
                        modelBuilder.Entity<Blog>(entity =>
                        {
                            entity.Property(e => e.Url).IsRequired();
                        });

                        modelBuilder.Entity<Post>(entity =>
                        {
                            entity.HasOne(d => d.Blog)
                                .WithMany(p => p.Post)
                                .HasForeignKey(d => d.BlogId);
                        });*/

            this.ModelBuilder(modelBuilder);
        }
        private void ModelBuilder(ModelBuilder modelBuilder)
        {
            //載入組件
            Assembly assembly = Assembly.Load("DS.Common");

            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsClass == true)
                {
                    if (type.FullName.Contains("DS.Common.Entities") == true)
                    {
                        //type.IsNestedFamily
                        var instance = Activator.CreateInstance(type) as ModelBase;
                        if (instance != null)
                        {
                            instance.ModelBuilder(modelBuilder);
                        }
                    }
                }
            }
        }
    }
}