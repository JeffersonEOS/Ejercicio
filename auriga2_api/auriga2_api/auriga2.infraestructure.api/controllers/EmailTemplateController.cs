using auriga2.infraestructure.application.models;
using auriga2.infraestructure.application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace auriga2.infraestructure.api.controllers;
[Route("api/emails_templates")]
[ApiController]
[Authorize]
public class EmailTemplateController : ControllerBase
{
    private readonly IApplicationService _applicationService;
    public EmailTemplateController(IApplicationService applicationService)
    {
        this._applicationService = applicationService;
    }
    [HttpPost]
    public ActionResult CreateEmailTemplate([FromBody] EmailTemplateModel emailTemplateModel) =>
        this.Ok(this._applicationService.CreateEmailTemplate(emailTemplateModel));
    [HttpPut]
    public ActionResult UpdateEmailTemplate([FromBody] EmailTemplateModel emailTemplateModel) =>
        this.Ok(this._applicationService.UpdateEmailTemplate(emailTemplateModel));
    [HttpDelete]
    public ActionResult DeleteEmailTemplate(System.Int32 id) =>
        this.Ok(this._applicationService.DeleteEmailTemplate(id));
    [HttpGet]
    public ActionResult GetAllEmailTemplateModels(int offset, int limit) =>
        this.Ok(this._applicationService.GetAllEmailTemplateModels(offset, limit));
    [HttpGet("filters")]
    public ActionResult GetEmailTemplateModelsByParam(string param) =>
        this.Ok(this._applicationService.GetEmailTemplateModelsByParam(param));
}
