using auriga2.domain.entities;
using auriga2.domain.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auriga2.infraestructure.application.models
{
    public class CuentaModel
    {
        public int Id { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Saldo { get; set; }
        public EnumTipoCuenta EnumTipoCuenta { get; set; }
        public int ClienteId { get; set; }
        public ClienteModel Cliente { get; set; } = null;
        //por que ponemos nulo ,por que el cliente ya tiene quye existir para agregar una cuenta
        public List<TransaccionModel> Transacciones { get; set; } = new();
        //inicializamos en vacio por problema de copilacion y primero tiene que existir
        //una cuenta para que exista Transaacion 
    }
}