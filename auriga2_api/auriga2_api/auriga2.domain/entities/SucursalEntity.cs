using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auriga2.domain.entities
{
    public class SucursalEntity
    {
         public int Id { get; set; }
         public string Nombre { get; set; }
         public string Direccion { get; set; }

        public int BancoId {  get; set; }
        public BancoEntity Banco { get; set; } = null;
        //por que le igualamos a nul por que al momento de agregar una sucursal el banco tiene que existir
        //att:jefferson
        public List<ClienteEntity> Clientes { get; set; }=new List<ClienteEntity>();
        //por que le igualamos a un objeto que vacio para poder crear la sucursal sin clientes
        //y luego lo vamos hacer123687

    }
}
