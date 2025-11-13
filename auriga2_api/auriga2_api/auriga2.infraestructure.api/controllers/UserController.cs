using auriga2.infraestructure.application.models;
using auriga2.infraestructure.application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace auriga2.infraestructure.api.controllers;
[Route("api/users")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IApplicationService _applicationService;
    public UserController(IApplicationService applicationService)
    {
        this._applicationService = applicationService;
    }
    [HttpPost]
    public ActionResult CreateUser([FromBody] UserModel userModel) =>
        this.Ok(this._applicationService.CreateUser(userModel));
    [HttpPut]
    public ActionResult UpdateUser([FromBody] UserModel userModel) =>
        this.Ok(this._applicationService.UpdateUser(userModel));
    [HttpDelete]
    public ActionResult DeleteUser(System.Int32 id) =>
        this.Ok(this._applicationService.DeleteUser(id));
    [HttpGet]
    public ActionResult GetAllUserModels(int offset, int limit) =>
        this.Ok(this._applicationService.GetAllUserModels(offset, limit));
    [HttpPost("assign-role")]
    [AllowAnonymous]
    public ActionResult AssignRoleToUser([FromBody] UserRoleModel userRoleModel)
    {
        var result = _applicationService.AssignRoleToUser(userRoleModel);
        return Ok(result);
    }
    [AllowAnonymous]
    [HttpPost("create-with-role/{roleId}")]
    public ActionResult CreateUserAndAssignRole(int roleId, [FromBody] UserModel userModel)
    {
        return this.Ok(this._applicationService.CreateUserAndAssignRole(userModel, roleId));
    }


    [HttpGet("filters")]
    public ActionResult GetUserModelsByParam(string param) =>
        this.Ok(this._applicationService.GetUserModelsByParam(param));
}
