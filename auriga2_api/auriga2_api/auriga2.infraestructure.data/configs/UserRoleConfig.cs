using auriga2.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace auriga2.infraestructure.data.configs;
public class UserRoleConfig : IEntityTypeConfiguration<UserRoleEntity>
{ 
    public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
    { 
        builder.ToTable("users_roles");
        builder.HasOne(x => x.Role)
            .WithMany(y => y.UserRoleList)
            .HasForeignKey(z => z.RoleId)
            .HasPrincipalKey(x => x.Id);
        builder.HasOne(x => x.User)
            .WithMany(y => y.UserRoleList)
            .HasForeignKey(z => z.UserId)
            .HasPrincipalKey(x => x.Id);
    }}