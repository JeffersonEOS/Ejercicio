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
        SucursalModel CreateSucursal(SucursalModel model);
        SucursalModel UpdateSucursal(SucursalModel model);
        bool DeleteSucursal(int id);
        PagedCollection<SucursalModel> GetAllSucursales(int offset, int limit);
        SucursalModel GetSucursalById(int id);
    }
}
