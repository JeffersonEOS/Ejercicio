using auriga2.infraestructure.application.models;
using auriga2.infraestructure.application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace auriga2.infraestructure.api.controllers;
[Route("api/configs")]
[ApiController]
[Authorize]
public class ConfigController : ControllerBase
{
    private readonly IApplicationService _applicationService;
    public ConfigController(IApplicationService applicationService)
    {
        this._applicationService = applicationService;
    }
    [HttpPost]
    public ActionResult CreateConfig([FromBody] ConfigModel configModel) =>
        this.Ok(this._applicationService.CreateConfig(configModel));
    [HttpPut]
    public ActionResult UpdateConfig([FromBody] ConfigModel configModel) =>
        this.Ok(this._applicationService.UpdateConfig(configModel));
    [HttpDelete]
    public ActionResult DeleteConfig(System.Int32 id) =>
        this.Ok(this._applicationService.DeleteConfig(id));
    [HttpGet]
    public ActionResult GetAllConfigModels(int offset, int limit) =>
        this.Ok(this._applicationService.GetAllConfigModels(offset, limit));
    [HttpGet("filters")]
    public ActionResult GetConfigModelsByParam(string param) =>
        this.Ok(this._applicationService.GetConfigModelsByParam(param));
}
