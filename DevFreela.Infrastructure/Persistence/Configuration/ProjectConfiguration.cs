using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
            .HasKey(p => p.id);

            builder
                .HasOne(p => p.Freelancer)
                .WithMany(u => u.FreelanceProject)
                .HasForeignKey(o => o.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);  // restrict impede se tiver fk com outra tabela

            builder
            .HasOne(p => p.Cliente)
            .WithMany(u => u.OwnerProject)
            .HasForeignKey(o => o.IdClient)
            .OnDelete(DeleteBehavior.Restrict);
           
        }
    }
}
