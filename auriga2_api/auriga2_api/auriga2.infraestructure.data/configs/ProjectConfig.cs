using auriga2.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace auriga2.infraestructure.data.configs;
public class ProjectConfig : IEntityTypeConfiguration<ProjectEntity>
{ 
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    { 
        builder.ToTable("projects");
        builder.HasOne(x => x.User)
            .WithMany(y => y.ProjectList)
            .HasForeignKey(z => z.UserId)
            .HasPrincipalKey(x => x.Id);
    }}