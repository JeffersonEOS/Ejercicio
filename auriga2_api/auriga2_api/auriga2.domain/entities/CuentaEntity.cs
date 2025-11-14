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
        public ClienteEntity Cliente { get; set; } = null;
        //por que ponemos nulo ,por que el cliente ya tiene quye existir para agregar una cuenta
        public List<TransaccionEntity> Transacciones { get; set; }=new List<TransaccionEntity>();
        //inicializamos en vacio por problema de copilacion y primero tiene que existir
        //una cuenta para que exista Transaacion 
    
    }
}
