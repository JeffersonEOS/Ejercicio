using auriga2.domain.models;
using auriga2.infraestructure.application.models;
namespace auriga2.infraestructure.application;
public partial interface IApplicationService
{ 
    UserModel CreateUser(UserModel userModel);
    UserRoleModel AssignRoleToUser(UserRoleModel userRoleModel);
    UserModel CreateUserAndAssignRole(UserModel userModel, int roleId);


    UserModel UpdateUser(UserModel userModel); 
    bool DeleteUser(System.Int32 id); 
    PagedCollection<UserModel> GetAllUserModels(int offset, int limit);
    PagedCollection<UserModel> GetUserModelsByParam(string param);
}