using auriga2.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auriga2.infraestructure.application.models
{
    public class BancoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ruc { get; set; }
        public string DireccionMatriz { get; set; }
        public List<SucursalModel> Sucursales { get; set; }
              = new ();
    }
}
