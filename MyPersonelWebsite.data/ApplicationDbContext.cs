using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyPersonelWebsite.Data.Models;

namespace MyPersonelWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<ProjectTag>()
                .HasKey(x => new { x.ProjectId, x.NomalizedTag });

            modelbuilder.Entity<ProjectTag>()
                .HasOne(pt => pt.project)
                .WithMany(p => p.TagLink)
                .HasForeignKey(pt => pt.ProjectId);

            modelbuilder.Entity<ProjectTag>()
                .HasOne(pt => pt.tag)
                .WithMany(p => p.ProjectLink)
                .HasForeignKey(pt => pt.NomalizedTag);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
