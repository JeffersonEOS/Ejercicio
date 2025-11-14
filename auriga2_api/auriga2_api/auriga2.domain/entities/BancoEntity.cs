using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auriga2.domain.entities
{
    public class BancoEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ruc { get; set; }
        public string DireccionMatriz { get; set; }
        public List<SucursalEntity> Sucursales { get; set; }
              = new List<SucursalEntity>();
    }
}
