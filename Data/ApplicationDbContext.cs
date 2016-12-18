using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASPNETCORE.Models;
using ASPNETCORE.Models.CategoryComponents;

namespace ASPNETCORE.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CategoryComponentType>()
                .HasKey(cct => new {cct.CategoryId, cct.ComponentTypeId});

            builder.Entity<CategoryComponentType>()
                .HasOne(c => c.Category)
                .WithMany(ct => ct.CategoryComponentTypes)
                .HasForeignKey(c => c.CategoryId);

            builder.Entity<CategoryComponentType>()
                .HasOne(ct => ct.ComponentType)
                .WithMany(c => c.CategoryComponentTypes)
                .HasForeignKey(ct => ct.ComponentTypeId);

            base.OnModelCreating(builder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }
        public DbSet<ESImage> ESImages { get; set; }
    }
}
