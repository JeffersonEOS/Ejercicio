using auriga2.domain.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auriga2.domain.entities
{
    public class CuentaEntity
    {
        public int Id { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Saldo { get; set; }
        public EnumTipoCuenta EnumTipoCuenta { get; set; }
        public int ClienteId { get; set; }
        public ClienteEntity? Cliente { get; set; } = null;

        //por que ponemos nulo ,por que el cliente ya tiene quye existir para agregar una cuenta
        public List<TransaccionEntity> Transacciones { get; set; }=new List<TransaccionEntity>();
        //inicializamos en vacio por problema de copilacion y primero tiene que existir
        //una cuenta para que exista Transaacion 
        public void Depositar(decimal monto)
        {
            if (monto <= 0)
                throw new ArgumentException("El monto a depositar debe ser mayor que cero.");

            Saldo += monto;

            Transacciones.Add(new TransaccionEntity
            {
                Monto = monto,

                Tipo = EnumTipoTransaccion.Deposito,
                Fecha = DateTime.Now,
                CuentaId = this.Id,
                Cuenta = this
            });
        }

        public void Retirar(decimal monto)
        {
            if (monto <= 0)
                throw new ArgumentException("El monto a retirar debe ser mayor que cero.");

            if (Saldo < monto)
                throw new InvalidOperationException("Saldo insuficiente para realizar el retiro.");

            Saldo -= monto;

            Transacciones.Add(new TransaccionEntity
            {
                Monto = monto,
                Tipo = enums.EnumTipoTransaccion.Retiro,
                Fecha = DateTime.Now,
                CuentaId = this.Id,
                Cuenta = this
            });

        }
    }
}
