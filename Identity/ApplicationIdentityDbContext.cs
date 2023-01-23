using Domain.Entities;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Identity
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options)
        {
        }

        public DbSet<RoleMenuPermission> RoleMenuPermission { get; set; }
        public DbSet<NavigationMenu> NavigationMenu { get; set; }

        public DbSet<UserCity_Network_Branch> UserCity_Network_Branch { get; set; }
        public DbSet<Cluster_Branch> Cluster_Branch { get; set; }
        public DbSet<User_Region> User_Region { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RoleMenuPermission>()
           .HasKey(c => new { c.RoleId, c.NavigationMenuId });

            base.OnModelCreating(modelBuilder);

        }
    }
}
