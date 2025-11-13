using auriga2.infraestructure.application.models;
using auriga2.infraestructure.application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace auriga2.infraestructure.api.controllers;
[Route("api/catalogs")]
[ApiController]
[Authorize]
public class CatalogController : ControllerBase
{
    private readonly IApplicationService _applicationService;
    public CatalogController(IApplicationService applicationService)
    {
        this._applicationService = applicationService;
    }
    [HttpPost]
    public ActionResult CreateCatalog([FromBody] CatalogModel catalogModel) =>
        this.Ok(this._applicationService.CreateCatalog(catalogModel));
    [HttpPut]
    public ActionResult UpdateCatalog([FromBody] CatalogModel catalogModel) =>
        this.Ok(this._applicationService.UpdateCatalog(catalogModel));
    [HttpDelete]
    public ActionResult DeleteCatalog(System.Int32 id) =>
        this.Ok(this._applicationService.DeleteCatalog(id));
    [HttpGet]
    public ActionResult GetAllCatalogModels(int offset, int limit) =>
        this.Ok(this._applicationService.GetAllCatalogModels(offset, limit));
    [HttpGet("filters")]
    public ActionResult GetCatalogModelsByParam(string param) =>
        this.Ok(this._applicationService.GetCatalogModelsByParam(param));
}
