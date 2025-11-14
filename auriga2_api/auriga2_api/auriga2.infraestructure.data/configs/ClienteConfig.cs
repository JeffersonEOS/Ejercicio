using auriga2.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace auriga2.infraestructure.data.configs
{
    public class ClienteConfig : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.ToTable("clientes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Correo)
                .HasColumnName("correo")
                .HasMaxLength(150);

            builder.Property(x => x.Telefono)
                .HasColumnName("telefono")
                .HasMaxLength(20);

            builder.Property(x => x.SucursalId)
                .HasColumnName("sucursal_id");

            // Cliente → Sucursal
            builder.HasOne(x => x.Sucursal)
                .WithMany(y => y.Clientes)
                .HasForeignKey(x => x.SucursalId);

            // Cliente → Cuentas
            builder.HasMany(x => x.Cuentas)
                .WithOne(y => y.Cliente)
                .HasForeignKey(y => y.ClienteId);
        }
    }
}
