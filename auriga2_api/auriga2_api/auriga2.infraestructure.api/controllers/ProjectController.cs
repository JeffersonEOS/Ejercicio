using auriga2.infraestructure.application.models;
using auriga2.infraestructure.application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace auriga2.infraestructure.api.controllers;
[Route("api/projects")]
[ApiController]
[Authorize]
public class ProjectController : ControllerBase
{
    private readonly IApplicationService _applicationService;
    public ProjectController(IApplicationService applicationService)
    {
        this._applicationService = applicationService;
    }
    [HttpPost]
    public ActionResult CreateProject([FromBody] ProjectModel projectModel) =>
        this.Ok(this._applicationService.CreateProject(projectModel));
    [HttpPut]
    public ActionResult UpdateProject([FromBody] ProjectModel projectModel) =>
        this.Ok(this._applicationService.UpdateProject(projectModel));
    [HttpDelete]
    public ActionResult DeleteProject(System.Int32 id) =>
        this.Ok(this._applicationService.DeleteProject(id));
    [HttpGet]
    public ActionResult GetAllProjectModels(int offset, int limit) =>
        this.Ok(this._applicationService.GetAllProjectModels(offset, limit));
    [HttpGet("filters")]
    public ActionResult GetProjectModelsByParam(string param) =>
        this.Ok(this._applicationService.GetProjectModelsByParam(param));
}
