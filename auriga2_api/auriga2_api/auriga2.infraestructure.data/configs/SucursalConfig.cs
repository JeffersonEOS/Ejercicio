using auriga2.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace auriga2.infraestructure.data.configs
{
    public class SucursalConfig : IEntityTypeConfiguration<SucursalEntity>
    {
        public void Configure(EntityTypeBuilder<SucursalEntity> builder)
        {
            builder.ToTable("sucursales");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Direccion)
                .HasColumnName("direccion")
                .HasMaxLength(150);

            builder.Property(x => x.BancoId)
                .HasColumnName("banco_id");

            // Relación Sucursal → Banco
            builder.HasOne(x => x.Banco)
                .WithMany(y => y.Sucursales)
                .HasForeignKey(x => x.BancoId);

            // Relación Sucursal → Clientes
            builder.HasMany(x => x.Clientes)
                .WithOne(y => y.Sucursal)
                .HasForeignKey(y => y.SucursalId);
        }
    }
}
