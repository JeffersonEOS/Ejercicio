using auriga2.infraestructure.application;
using auriga2.infraestructure.application.models.requests;
using auriga2.infraestructure.application.models.responses;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace auriga2.infraestructure.api.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class MovimientoController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public MovimientoController(IApplicationService movimientoService)
        {
            _applicationService = movimientoService;
        }

        [HttpPost("depositar")]
        public async Task<ActionResult<MovimientoResponseDto>> Depositar([FromBody] MovimientoRequestDto request)
        {
            try
            {
                var response = await _applicationService.DepositarAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("retirar")]
        public async Task<ActionResult<MovimientoResponseDto>> Retirar([FromBody] MovimientoRequestDto request)
        {
            try
            {
                var response = await _applicationService.RetirarAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("saldo/{numeroCuenta}")]
        public async Task<ActionResult<decimal>> ObtenerSaldo(string numeroCuenta)
        {
            try
            {
                var request = new MovimientoRequestDto { NumeroCuenta = numeroCuenta };
                var cuenta = await _applicationService.ObtenerCuentaAsync(request);
                if (cuenta == null)
                    return NotFound("Cuenta no encontrada");

                return Ok(cuenta.SaldoActual);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
