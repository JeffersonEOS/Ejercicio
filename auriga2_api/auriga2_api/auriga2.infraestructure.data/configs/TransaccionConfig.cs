using auriga2.domain.entities;
using auriga2.domain.enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace auriga2.infraestructure.data.configs
{
    public class TransaccionConfig : IEntityTypeConfiguration<TransaccionEntity>
    {
        public void Configure(EntityTypeBuilder<TransaccionEntity> builder)
        {
            builder.ToTable("transacciones");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Monto)
                .HasColumnName("monto")
                .HasColumnType("decimal(18,2)");

            builder.Property(t => t.Tipo)
                   .HasColumnName("tipo").IsRequired(true).HasMaxLength(50).HasConversion<string>();


            builder.Property(x => x.Fecha)
                .HasColumnName("fecha")
                .HasColumnType("datetime");

            builder.Property(x => x.CuentaId)
                .HasColumnName("cuenta_id");

            // Transacción → Cuenta
            builder.HasOne(x => x.Cuenta)
                .WithMany(y => y.Transacciones)
                .HasForeignKey(x => x.CuentaId);
        }
    }
}
