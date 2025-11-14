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
        TransaccionModel CreateTransaccion(TransaccionModel model);
        TransaccionModel UpdateTransaccion(TransaccionModel model);
        bool DeleteTransaccion(int id);
        PagedCollection<TransaccionModel> GetAllTransacciones(int offset, int limit);
        TransaccionModel GetTransaccionById(int id);
    }
}
