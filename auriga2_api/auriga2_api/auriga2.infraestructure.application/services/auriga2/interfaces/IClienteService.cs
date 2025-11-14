using auriga2.domain.models;
using auriga2.infraestructure.application.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auriga2.infraestructure.application
{
    public partial interface IApplicationService
    {
        ClienteModel CreateCliente(ClienteModel model);
        ClienteModel UpdateCliente(ClienteModel model);
        bool DeleteCliente(int id);
        PagedCollection<ClienteModel> GetAllClientes(int offset, int limit);
        ClienteModel GetClienteById(int id);
    }
}
