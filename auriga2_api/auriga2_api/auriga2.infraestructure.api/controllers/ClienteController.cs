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
    [Route("api/clientes")]
    [ApiController]
    [AllowAnonymous]
    public class ClienteController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ClienteController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public ActionResult<ClienteModel> CreateCliente([FromBody] ClienteModel model) =>
            Ok(_applicationService.CreateCliente(model));

        [HttpPut]
        public ActionResult<ClienteModel> UpdateCliente([FromBody] ClienteModel model) =>
            Ok(_applicationService.UpdateCliente(model));

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteCliente(int id) =>
            Ok(_applicationService.DeleteCliente(id));

        [HttpGet]
        public ActionResult<PagedCollection<ClienteModel>> GetAllClientes(int offset, int limit) =>
            Ok(_applicationService.GetAllClientes(offset, limit));

        [HttpGet("{id}")]
        public ActionResult<ClienteModel> GetClienteById(int id) =>
            Ok(_applicationService.GetClienteById(id));
    }
}
