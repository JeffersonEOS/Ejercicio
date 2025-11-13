using auriga2.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace auriga2.infraestructure.data.configs;
public class UserInterestConfig : IEntityTypeConfiguration<UserInterestEntity>
{ 
    public void Configure(EntityTypeBuilder<UserInterestEntity> builder)
    { 
        builder.ToTable("users_interests");
        builder.HasOne(x => x.User)
            .WithMany(y => y.UserInterestList)
            .HasForeignKey(z => z.UserId)
            .HasPrincipalKey(x => x.Id);
    }}