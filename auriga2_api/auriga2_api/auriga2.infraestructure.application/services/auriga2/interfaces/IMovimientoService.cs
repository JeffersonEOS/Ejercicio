using auriga2.infraestructure.application.models.requests;
using auriga2.infraestructure.application.models.responses;
using System.Threading.Tasks;

namespace auriga2.infraestructure.application
{
    public partial interface IApplicationService
    {
        Task<MovimientoResponseDto> DepositarAsync(MovimientoRequestDto request);
        Task<MovimientoResponseDto> RetirarAsync(MovimientoRequestDto request);
        Task<MovimientoResponseDto> ObtenerCuentaAsync(MovimientoRequestDto request);
    }
}
