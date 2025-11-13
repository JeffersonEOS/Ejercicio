using auriga2.infraestructure.application;
using auriga2.infraestructure.application.models;
using auriga2.infraestructure.application.models.requests;
using Microsoft.AspNetCore.Mvc;

namespace auriga2.infraestructure.api.controllers;

[Route("api/authorizations")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public AuthenticationController(
        IApplicationService applicationService)
    {
        this._applicationService = applicationService;
    }

    [HttpPost]
    public ActionResult<LoginResponseModel> GetLogin([FromBody] LoginRequestModel loginRequestModel) =>
        Ok(this._applicationService.Login(loginRequestModel));
}