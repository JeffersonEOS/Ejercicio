using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auriga2.infraestructure.application.services.EnvioCorreo.Models
{
    public class EmailSettings
    {
        public string CorreoRemitente { get; set; }
        public string NombreRemitente { get; set; }
        public string AppPassword { get; set; }
    }
}
