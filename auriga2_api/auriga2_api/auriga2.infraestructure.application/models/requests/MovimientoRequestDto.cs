using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auriga2.infraestructure.application.models.requests
{
    public class MovimientoRequestDto
    {
        public string NumeroCuenta { get; set; }
        public decimal Monto { get; set; }
    }
}
