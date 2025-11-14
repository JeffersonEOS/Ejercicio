using auriga2.domain.entities;
using auriga2.domain.repositories;
using auriga2.infraestructure.data.contexts;
using auriga2.infraestructure.data.repositories.generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auriga2.infraestructure.data.repositories
{

    public class CuentaRepository : GenericDataDbRepository<CuentaEntity>, ICuentaDomainRepository
    {
        public CuentaRepository(Auriga2Context context) : base(context)
        {
            Context = context;
        }
        public async Task<CuentaEntity> ObtenerPorNumeroCuentaAsync(string numeroCuenta)
        {
            return await Context.Cuentas
                .Include(c => c.Cliente)          // Esto carga el cliente relacionado
                .Include(c => c.Transacciones)    // Esto carga las transacciones
                .FirstOrDefaultAsync(c => c.NumeroCuenta == numeroCuenta);
        }


        public async Task ActualizarAsync(CuentaEntity cuenta)
        {
            Context.Cuentas.Update(cuenta);
            await Context.SaveChangesAsync();
        }
        public async Task<CuentaEntity> ObtenerCuentaAsync(string numeroCuenta)
        {
            return await Context.Cuentas
                .Include(c => c.Cliente)        // carga el cliente
                .Include(c => c.Transacciones)   // carga transacciones si necesitas
                .FirstOrDefaultAsync(c => c.NumeroCuenta == numeroCuenta);
        }



    }
}
