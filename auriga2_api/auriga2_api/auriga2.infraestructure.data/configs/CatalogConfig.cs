using auriga2.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace auriga2.infraestructure.data.configs;
public class CatalogConfig : IEntityTypeConfiguration<CatalogEntity>
{ 
    public void Configure(EntityTypeBuilder<CatalogEntity> builder)
    { 
        builder.ToTable("catalogs");
        builder.HasOne(x => x.Catalog)
            .WithMany(y => y.CatalogList)
            .HasForeignKey(z => z.ParentId)
            .HasPrincipalKey(x => x.Id);
        builder.HasMany(x => x.CatalogList)
            .WithOne(y => y.Catalog);
    }}