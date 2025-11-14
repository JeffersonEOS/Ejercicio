using auriga2.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auriga2.infraestructure.application.models
{
    public class TransaccionModel
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public CuentaModel Cuenta { get; set; } = null;
    }
}
