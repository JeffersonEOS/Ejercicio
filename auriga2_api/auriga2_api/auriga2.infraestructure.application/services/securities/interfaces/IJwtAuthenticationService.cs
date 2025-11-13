using auriga2.infraestructure.application.models;
using auriga2.infraestructure.application.models.requests;

namespace auriga2.infraestructure.application;

public partial interface IApplicationService
{
    LoginResponseModel Login(LoginRequestModel loginRequestModel);
}