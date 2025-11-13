using auriga2.infraestructure.application.models;
using auriga2.infraestructure.application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace auriga2.infraestructure.api.controllers;
[Route("api/users_roles")]
[ApiController]
[Authorize]
public class UserRoleController : ControllerBase
{
    private readonly IApplicationService _applicationService;
    public UserRoleController(IApplicationService applicationService)
    {
        this._applicationService = applicationService;
    }
    [HttpPost]
    public ActionResult CreateUserRole([FromBody] UserRoleModel userRoleModel) =>
        this.Ok(this._applicationService.CreateUserRole(userRoleModel));
    [HttpPut]
    public ActionResult UpdateUserRole([FromBody] UserRoleModel userRoleModel) =>
        this.Ok(this._applicationService.UpdateUserRole(userRoleModel));
    [HttpDelete]
    public ActionResult DeleteUserRole(System.Int32 id) =>
        this.Ok(this._applicationService.DeleteUserRole(id));
    [HttpGet]
    public ActionResult GetAllUserRoleModels(int offset, int limit) =>
        this.Ok(this._applicationService.GetAllUserRoleModels(offset, limit));
    [HttpGet("filters")]
    public ActionResult GetUserRoleModelsByParam(string param) =>
        this.Ok(this._applicationService.GetUserRoleModelsByParam(param));
}
