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
        BancoModel CreateBanco(BancoModel model);
        BancoModel UpdateBanco(BancoModel model);
        bool DeleteBanco(int id);
        PagedCollection<BancoModel> GetAllBancos(int offset, int limit);
        BancoModel GetBancoById(int id);
    }
}
