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
    [Route("api/transacciones")]
    [ApiController]
    [Authorize]
    public class TransaccionController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public TransaccionController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public ActionResult<TransaccionModel> CreateTransaccion([FromBody] TransaccionModel model) =>
            Ok(_applicationService.CreateTransaccion(model));

        [HttpPut]
        public ActionResult<TransaccionModel> UpdateTransaccion([FromBody] TransaccionModel model) =>
            Ok(_applicationService.UpdateTransaccion(model));

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteTransaccion(int id) =>
            Ok(_applicationService.DeleteTransaccion(id));

        [HttpGet]
        public ActionResult<PagedCollection<TransaccionModel>> GetAllTransacciones(int offset, int limit) =>
            Ok(_applicationService.GetAllTransacciones(offset, limit));

        [HttpGet("{id}")]
        public ActionResult<TransaccionModel> GetTransaccionById(int id) =>
            Ok(_applicationService.GetTransaccionById(id));
    }
}
