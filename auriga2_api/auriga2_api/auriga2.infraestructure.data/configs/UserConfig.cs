using auriga2.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace auriga2.infraestructure.data.configs;
public class UserConfig : IEntityTypeConfiguration<UserEntity>
{ 
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    { 
        builder.ToTable("users");
        builder.HasMany(x => x.UserRoleList)
            .WithOne(y => y.User);
        builder.HasMany(x => x.ProjectList)
            .WithOne(y => y.User);
        builder.HasMany(x => x.UserInterestList)
            .WithOne(y => y.User);
    }}