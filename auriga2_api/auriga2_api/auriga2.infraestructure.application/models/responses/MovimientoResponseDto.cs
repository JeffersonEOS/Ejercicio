using auriga2.domain.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auriga2.infraestructure.application.models.responses
{
    public class MovimientoResponseDto
    {
        public string NumeroCuenta { get; set; }
        public decimal SaldoActual { get; set; }
        public decimal Monto { get; set; }
        public EnumTipoTransaccion Tipo { get; set; }   
        public DateTime Fecha { get; set; }
    }
}
