using auriga2.domain.models;
using auriga2.infraestructure.application.models;
namespace auriga2.infraestructure.application;
public partial interface IApplicationService
{ 
    UserRoleModel CreateUserRole(UserRoleModel userRoleModel); 
    UserRoleModel UpdateUserRole(UserRoleModel userRoleModel); 
    bool DeleteUserRole(System.Int32 id); 
    PagedCollection<UserRoleModel> GetAllUserRoleModels(int offset, int limit);
    PagedCollection<UserRoleModel> GetUserRoleModelsByParam(string param);
}