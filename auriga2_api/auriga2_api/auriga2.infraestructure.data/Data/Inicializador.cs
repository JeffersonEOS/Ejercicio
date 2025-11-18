using auriga2.domain.entities;
using auriga2.infraestructure.data.contexts;
using Microsoft.EntityFrameworkCore;
using System;

namespace auriga2.infraestructure.data.Data
{
    public static class Inicializador
    {
        public static async Task SeedAsync(Auriga2Context context)
        {
            await context.Database.MigrateAsync();

            if (!context.Bancos.Any())
            {
                var bancos = new List<BancoEntity>
            {
                new BancoEntity { Nombre = "Banco Pichincha", Ruc="179001", DireccionMatriz="Quito" },
                new BancoEntity { Nombre = "Banco Guayaquil", Ruc="099008", DireccionMatriz="Guayaquil" },
                new BancoEntity { Nombre = "Banco Internacional", Ruc="179112", DireccionMatriz="Quito" }
            };

                context.Bancos.AddRange(bancos);
                await context.SaveChangesAsync();
            }

            var banco1 = context.Bancos.First(b => b.Nombre == "Banco Pichincha").Id;
            var banco2 = context.Bancos.First(b => b.Nombre == "Banco Guayaquil").Id;
            var banco3 = context.Bancos.First(b => b.Nombre == "Banco Internacional").Id;

            if (!context.Sucursales.Any())
            {
                var sucursales = new List<SucursalEntity>
            {
                new SucursalEntity { Nombre = "Sucursal Quito Norte", Direccion="Av. Naciones Unidas", BancoId = banco1 },
                new SucursalEntity { Nombre = "Sucursal Quito Sur", Direccion="Av. Maldonado", BancoId = banco1 },

                new SucursalEntity { Nombre = "Sucursal Guayaquil Centro", Direccion="9 de Octubre", BancoId = banco2 },
                new SucursalEntity { Nombre = "Sucursal Mall del Sol", Direccion="Mall del Sol", BancoId = banco2 },

                new SucursalEntity { Nombre = "Sucursal Cuenca El Centro", Direccion="Calle Bolívar", BancoId = banco3 },
                new SucursalEntity { Nombre = "Sucursal Cuenca Río", Direccion="Av. Loja", BancoId = banco3 }
            };

                context.Sucursales.AddRange(sucursales);
                await context.SaveChangesAsync();
            }

            var suc1 = context.Sucursales.First(s => s.Nombre == "Sucursal Quito Norte").Id;
            var suc3 = context.Sucursales.First(s => s.Nombre == "Sucursal Guayaquil Centro").Id;

            if (!context.Clientes.Any())
            {
                var clientes = new List<ClienteEntity>
            {
                new ClienteEntity
                {
                    Nombre = "Jefferson Alvarez",
                    Correo = "jefferson@mail.com",
                    Telefono = "0999999999",
                    SucursalId = suc1
                },
                new ClienteEntity
                {
                    Nombre = "Doris Vaca",
                    Correo = "doris@mail.com",
                    Telefono = "0988888888",
                    SucursalId = suc3
                }
            };

                context.Clientes.AddRange(clientes);
                await context.SaveChangesAsync();
            }

            var cli1 = context.Clientes.First(c => c.Nombre == "Jefferson Alvarez").Id;
            var cli2 = context.Clientes.First(c => c.Nombre == "Doris Vaca").Id;

            if (!context.Cuentas.Any())
            {
                var cuentas = new List<CuentaEntity>
            {
                new CuentaEntity
                {
                    NumeroCuenta = "100001",
                    Saldo = 500,
                    EnumTipoCuenta = auriga2.domain.enums.EnumTipoCuenta.Ahorro,
                    ClienteId = cli1
                },
                new CuentaEntity
                {
                    NumeroCuenta = "200001",
                    Saldo = 750,
                    EnumTipoCuenta = auriga2.domain.enums.EnumTipoCuenta.Corriente,
                    ClienteId = cli2
                }
            };

                context.Cuentas.AddRange(cuentas);
                await context.SaveChangesAsync();
            }
        }
    }




}
