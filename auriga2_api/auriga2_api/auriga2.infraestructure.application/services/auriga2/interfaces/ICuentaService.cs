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
        CuentaModel CreateCuenta(CuentaModel model);
        CuentaModel UpdateCuenta(CuentaModel model);
        bool DeleteCuenta(int id);
        PagedCollection<CuentaModel> GetAllCuentas(int offset, int limit);
        CuentaModel GetCuentaById(int id);
    }
}
