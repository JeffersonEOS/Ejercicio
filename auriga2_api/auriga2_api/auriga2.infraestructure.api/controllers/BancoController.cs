using auriga2.domain.entities;
using auriga2.domain.models;
using auriga2.infraestructure.application;
using auriga2.infraestructure.application.models;
using auriga2.infraestructure.util;
using auriga2.infraestructure.util.exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace auriga2.infraestructure.api.controllers
{
    [Route("api/bancos")]
    [ApiController]
    [AllowAnonymous]
    public class BancoController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public BancoController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public ActionResult<BancoModel> CreateBanco([FromBody] BancoModel model) =>
            Ok(_applicationService.CreateBanco(model));

        [HttpPut]
        public ActionResult<BancoModel> UpdateBanco([FromBody] BancoModel model) =>
            Ok(_applicationService.UpdateBanco(model));

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteBanco(int id) =>
            Ok(_applicationService.DeleteBanco(id));

        [HttpGet]
        public ActionResult<ICollection<BancoModel>> GetAllBancos(int offset, int limit)
         => Ok(_applicationService.GetAllBancos(offset, limit));


        [HttpGet("{id}")]
        public ActionResult<BancoModel> GetBancoById(int id) =>
            Ok(_applicationService.GetBancoById(id));
    }
}
