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
    [Route("api/cuentas")]
    [ApiController]
    [AllowAnonymous]
    public class CuentaController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public CuentaController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public ActionResult<CuentaModel> CreateCuenta([FromBody] CuentaModel model) =>
            Ok(_applicationService.CreateCuenta(model));

        [HttpPut]
        public ActionResult<CuentaModel> UpdateCuenta([FromBody] CuentaModel model) =>
            Ok(_applicationService.UpdateCuenta(model));

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteCuenta(int id) =>
            Ok(_applicationService.DeleteCuenta(id));

        [HttpGet]
        public ActionResult<PagedCollection<CuentaModel>> GetAllCuentas(int offset, int limit) =>
            Ok(_applicationService.GetAllCuentas(offset, limit));

        [HttpGet("{id}")]
        public ActionResult<CuentaModel> GetCuentaById(int id) =>
            Ok(_applicationService.GetCuentaById(id));
    }
}
