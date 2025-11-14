using auriga2.domain.entities;
using System.Threading.Tasks;

namespace auriga2.domain.repositories
{
    public interface ICuentaDomainRepository : IGenericDataRepository<CuentaEntity>
    {
        Task<CuentaEntity> ObtenerPorNumeroCuentaAsync(string numeroCuenta);
        Task ActualizarAsync(CuentaEntity cuenta);
        Task<CuentaEntity> ObtenerCuentaAsync(string numeroCuenta);
    }
}
