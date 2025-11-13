using auriga2.domain.models;
using auriga2.infraestructure.application.models;
namespace auriga2.infraestructure.application;
public partial interface IApplicationService
{ 
    UserInterestModel CreateUserInterest(UserInterestModel userInterestModel); 
    UserInterestModel UpdateUserInterest(UserInterestModel userInterestModel); 
    bool DeleteUserInterest(System.Int32 id); 
    PagedCollection<UserInterestModel> GetAllUserInterestModels(int offset, int limit);
    PagedCollection<UserInterestModel> GetUserInterestModelsByParam(string param);
}