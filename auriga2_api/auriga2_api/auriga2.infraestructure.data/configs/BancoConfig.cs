using auriga2.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace auriga2.infraestructure.data.configs
{
    public class BancoConfig : IEntityTypeConfiguration<BancoEntity>
    {
        public void Configure(EntityTypeBuilder<BancoEntity> builder)
        {
            builder.ToTable("bancos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Ruc)
                .HasColumnName("ruc")
                .HasMaxLength(13);

            builder.Property(x => x.DireccionMatriz)
                .HasColumnName("direccion_matriz")
                .HasMaxLength(200);

      
            builder.HasMany(x => x.Sucursales)
                .WithOne(y => y.Banco)
                .HasForeignKey(y => y.BancoId);
        }
    }
}
