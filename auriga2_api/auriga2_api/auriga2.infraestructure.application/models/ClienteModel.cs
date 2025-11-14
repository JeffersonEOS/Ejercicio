using auriga2.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auriga2.infraestructure.application.models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int SucursalId { get; set; }

        public SucursalModel Sucursal { get; set; } = null;
        //un cliente solo tiene una sucursal
        //por que se le inicializa en null por que una sucursal ya debe de existir
        //al agregar un cliente 
        public List<CuentaModel> Cuentas { get; set; } =new ();

        //por que se crea un obj vacion a cuenta por que toca crear primero el cliente para luego crear
        //las cuentas si no tendriamos un error en copilacion de valor nulo en este campo
        //por que un cliente tiene que existir primero y luego las cuentas
    }
}
