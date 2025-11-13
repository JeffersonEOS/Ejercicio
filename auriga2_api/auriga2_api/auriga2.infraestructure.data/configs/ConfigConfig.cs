using auriga2.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace auriga2.infraestructure.data.configs;
public class ConfigConfig : IEntityTypeConfiguration<ConfigEntity>
{ 
    public void Configure(EntityTypeBuilder<ConfigEntity> builder)
    { 
        builder.ToTable("configs");
    }}