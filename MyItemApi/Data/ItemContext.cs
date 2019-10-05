using Microsoft.EntityFrameworkCore;
using MyItemApi.Data.Entities;
using MyNoteApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNoteApi.Data
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) :base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<AttributeCategory> AttributeCategories { get; set; }
        public DbSet<AttributeName> AttributeNames { get; set; }
        public DbSet<AttributeValue> AttributeValues { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemText> ItemTexts { get; set; }
        public DbSet<ItemData> ItemDatas { get; set; }
        public DbSet<ItemAttribute> ItemAttributes { get; set; }
        public DbSet<Hierarchy> Hierarchies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Log>()
                .HasOne(l => l.CreatedBy)
                .WithMany(u => u.LogCreatedAt)
                .HasForeignKey(l=>l.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Log>()
                .HasOne(l => l.UpdatedBy)
                .WithMany(u => u.LogUpdatedAt)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Hierarchy>()
                .HasOne(h=>h.Item)
                .WithMany(i=>i.HierarchyItems)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Hierarchy>()
                .HasOne(h => h.ParentItem)
                .WithMany(i => i.HierarchyParentItems)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemAttribute>()
                .HasOne(i => i.Log)
                .WithOne(l => l.ItemAttribute)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemData>()
                .HasOne(i => i.Log)
                .WithOne(l => l.ItemData)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemText>()
                .HasOne(i => i.Log)
                .WithOne(l => l.ItemText)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Log>()
            //    .WithMany()
            //    .HasMany<Hierarchy>()
            //    .WithOne()
            //    .HasForeignKey(h => h.ParentHierarchyId);



        }

    }
}
