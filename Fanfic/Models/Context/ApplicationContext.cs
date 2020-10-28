using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models.Context
{
    public class ApplicationContext: IdentityDbContext<User>
    {
        public DbSet<Composition> Compositions { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
          : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TagComposition>()
                .HasKey(sc => new { sc.TagId, sc.CompositionId });

            modelBuilder.Entity<TagComposition>()
                .HasOne(sc => sc.Composition)
                .WithMany(s => s.Tags)
                .HasForeignKey(sc => sc.CompositionId);

            modelBuilder.Entity<TagComposition>()
                .HasOne(sc => sc.Tag)
                .WithMany(c => c.Compositions)
                .HasForeignKey(sc => sc.TagId);

        }
    }
}
