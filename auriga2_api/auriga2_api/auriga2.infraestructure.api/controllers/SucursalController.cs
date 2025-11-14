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
    [Route("api/sucursales")]
    [ApiController]
    [AllowAnonymous]
    public class SucursalController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public SucursalController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public ActionResult<SucursalModel> CreateSucursal([FromBody] SucursalModel model) =>
            Ok(_applicationService.CreateSucursal(model));

        [HttpPut]
        public ActionResult<SucursalModel> UpdateSucursal([FromBody] SucursalModel model) =>
            Ok(_applicationService.UpdateSucursal(model));

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteSucursal(int id) =>
            Ok(_applicationService.DeleteSucursal(id));

        [HttpGet]
        public ActionResult<PagedCollection<SucursalModel>> GetAllSucursales(int offset, int limit) =>
            Ok(_applicationService.GetAllSucursales(offset, limit));

        [HttpGet("{id}")]
        public ActionResult<SucursalModel> GetSucursalById(int id) =>
            Ok(_applicationService.GetSucursalById(id));
    }
}
