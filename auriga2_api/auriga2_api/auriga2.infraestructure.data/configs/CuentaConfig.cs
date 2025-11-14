using auriga2.domain.entities;
using auriga2.domain.enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace auriga2.infraestructure.data.configs
{
    public class CuentaConfig : IEntityTypeConfiguration<CuentaEntity>
    {
        public void Configure(EntityTypeBuilder<CuentaEntity> builder)
        {
            builder.ToTable("cuentas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.NumeroCuenta)
                .HasColumnName("numero_cuenta")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Saldo)
                .HasColumnName("saldo")
                .HasColumnType("decimal(18,2)");
            builder.Property(x => x.EnumTipoCuenta)
           .HasColumnName("tipo_cuenta")
           .HasConversion<string>();



            builder.Property(x => x.ClienteId)
                .HasColumnName("cliente_id");

            // Cuenta → Cliente
            builder.HasOne(x => x.Cliente)
                .WithMany(y => y.Cuentas)
                .HasForeignKey(x => x.ClienteId);

            // Cuenta → Transacciones
            builder.HasMany(x => x.Transacciones)
                .WithOne(y => y.Cuenta)
                .HasForeignKey(y => y.CuentaId);
        }
    }
}
