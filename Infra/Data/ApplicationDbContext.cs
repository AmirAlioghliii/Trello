using Infra.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Trello_.Models;

namespace Trello_.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole > ApplicationRoles { get; set; }
        public DbSet<UserTask> UserTasks{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationRole>().HasData(new ApplicationRole() { Name = "Admin", NormalizedName = "ADMIN" });

        }
    }
}
