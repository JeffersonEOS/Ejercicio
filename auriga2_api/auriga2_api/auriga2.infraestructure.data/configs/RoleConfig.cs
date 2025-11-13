using auriga2.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace auriga2.infraestructure.data.configs;
public class RoleConfig : IEntityTypeConfiguration<RoleEntity>
{ 
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    { 
        builder.ToTable("roles");
        builder.HasMany(x => x.UserRoleList)
            .WithOne(y => y.Role);
    }}