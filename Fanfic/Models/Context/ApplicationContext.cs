using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models.Context
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Composition> Compositions { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagComposition> TagCompositions { get; set; }

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

        public static async Task CreateAdminAccount(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string userName = configuration["Data:AdminUser:Name"];
            string email = configuration["Data:AdminUser:Email"];
            string password = configuration["Data:AdminUser:Password"];
            string role = configuration["Data:AdminUser:Role"];

            if (await userManager.FindByEmailAsync(email) == null)
            {
                await CreateRoleAsync(roleManager, role);
                await CreateRoleAsync(roleManager, "User");

                User user = new User
                {
                    Name = userName,
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }

            }
        }
        public static async Task CreateRoleAsync(RoleManager<IdentityRole> roleManager, string name)
        {
            if (await roleManager.FindByNameAsync(name) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(name));
            }
        }
    }


}
