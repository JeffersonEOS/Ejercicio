using auriga2.infraestructure.application.models;
using auriga2.infraestructure.application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace auriga2.infraestructure.api.controllers;
[Route("api/roles")]
[ApiController]
[AllowAnonymous]
public class RoleController : ControllerBase
{
    private readonly IApplicationService _applicationService;
    public RoleController(IApplicationService applicationService)
    {
        this._applicationService = applicationService;
    }
    [HttpPost]
    public ActionResult CreateRole([FromBody] RoleModel roleModel) =>
        this.Ok(this._applicationService.CreateRole(roleModel));
    [HttpPut]
    public ActionResult UpdateRole([FromBody] RoleModel roleModel) =>
        this.Ok(this._applicationService.UpdateRole(roleModel));
    [HttpDelete]
    public ActionResult DeleteRole(System.Int32 id) =>
        this.Ok(this._applicationService.DeleteRole(id));
    [HttpGet]
    public ActionResult GetAllRoleModels(int offset, int limit) =>
        this.Ok(this._applicationService.GetAllRoleModels(offset, limit));
    [HttpGet("filters")]
    public ActionResult GetRoleModelsByParam(string param) =>
        this.Ok(this._applicationService.GetRoleModelsByParam(param));
}
