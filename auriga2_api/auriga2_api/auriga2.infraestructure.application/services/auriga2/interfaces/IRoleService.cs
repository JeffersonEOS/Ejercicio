using auriga2.domain.models;
using auriga2.infraestructure.application.models;
namespace auriga2.infraestructure.application;
public partial interface IApplicationService
{ 
    RoleModel CreateRole(RoleModel roleModel); 
    RoleModel UpdateRole(RoleModel roleModel); 
    bool DeleteRole(System.Int32 id); 
    PagedCollection<RoleModel> GetAllRoleModels(int offset, int limit);
    PagedCollection<RoleModel> GetRoleModelsByParam(string param);
}