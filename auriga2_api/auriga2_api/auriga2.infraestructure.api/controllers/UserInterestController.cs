using auriga2.infraestructure.application.models;
using auriga2.infraestructure.application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace auriga2.infraestructure.api.controllers;
[Route("api/users_interests")]
[ApiController]
[AllowAnonymous]
public class UserInterestController : ControllerBase
{
    private readonly IApplicationService _applicationService;
    public UserInterestController(IApplicationService applicationService)
    {
        this._applicationService = applicationService;
    }
    [HttpPost]
    public ActionResult CreateUserInterest([FromBody] UserInterestModel userInterestModel) =>
        this.Ok(this._applicationService.CreateUserInterest(userInterestModel));
    [HttpPut]
    public ActionResult UpdateUserInterest([FromBody] UserInterestModel userInterestModel) =>
        this.Ok(this._applicationService.UpdateUserInterest(userInterestModel));
    [HttpDelete]
    public ActionResult DeleteUserInterest(System.Int32 id) =>
        this.Ok(this._applicationService.DeleteUserInterest(id));
    [HttpGet]
    public ActionResult GetAllUserInterestModels(int offset, int limit) =>
        this.Ok(this._applicationService.GetAllUserInterestModels(offset, limit));
    [HttpGet("filters")]
    public ActionResult GetUserInterestModelsByParam(string param) =>
        this.Ok(this._applicationService.GetUserInterestModelsByParam(param));
}
