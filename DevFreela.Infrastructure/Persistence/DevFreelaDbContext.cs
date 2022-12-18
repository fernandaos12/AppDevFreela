using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }
        public DbSet<Login> UserLogin { get; set; }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Project>()
                .HasKey(p => p.id);

            modelbuilder.Entity<Project>()
                .HasOne(p => p.Freelancer)
                .WithMany(u => u.FreelanceProject)
                .HasForeignKey(o => o.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);  // restrict impede se tiver fk com outra tabela
           
            modelbuilder.Entity<Project>()
            .HasOne(p => p.Cliente)
            .WithMany(u => u.OwnerProject)
            .HasForeignKey(o => o.IdClient)
            .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<ProjectComment>()
                .HasKey(p => p.id);   
            
            modelbuilder.Entity<ProjectComment>()
                .HasOne(p => p.Project)
                .WithMany(p => p.Comments)
                .HasForeignKey(p=> p.IdProjet)
                .OnDelete(DeleteBehavior.Restrict);  
            
            modelbuilder.Entity<ProjectComment>()
                .HasOne(p => p.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(p=> p.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Login>()
                .HasKey(p => p.id);

            modelbuilder.Entity<User>()
                .HasKey(p => p.id);

            modelbuilder.Entity<User>()               
                .HasMany(u => u.Skills)
                .WithOne()
                .HasForeignKey(u => u.IdSkill);

            modelbuilder.Entity<Skill>()
                .HasKey(p => p.id);


        }


    }
}
