using auriga2.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auriga2.infraestructure.application.models
{
    public class SucursalModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public int BancoId { get; set; }
        public BancoModel? Banco { get; set; } = null;
        //se pone al incio ? para q aepte valor nulo completo 
        //por que le igualamos a nul por que al momento de agregar una sucursal el banco tiene que existir
        //att:jefferson
        public List<ClienteModel> Clientes { get; set; } = new();
        //por que le igualamos a un objeto que vacio para poder crear la sucursal sin clientes
        //y luego lo vamos hacer123687

    }
}
