using auriga2.domain.entities;
using auriga2.domain.models;
using auriga2.infraestructure.application.models;
using auriga2.infraestructure.util;
using auriga2.infraestructure.util.exceptions;

namespace auriga2.infraestructure.application
{
    public partial class ApplicationService : IApplicationService
    {
        public CuentaModel CreateCuenta(CuentaModel model)
        {
            CuentaEntity cuenta = this._mapper.Map<CuentaEntity>(model);
            this._cuentaDomainRepository.AddSync(cuenta);
            return this._mapper.Map<CuentaModel>(cuenta);
        }

        public CuentaModel UpdateCuenta(CuentaModel model)
        {
            CuentaEntity cuentaEntity = this._cuentaDomainRepository
                .FirstOrDefaultSync(x => x.Id == model.Id);

            if (cuentaEntity == null)
                throw new CustomException(ExceptionSettings.NOT_FOUND);

            cuentaEntity = this._mapper.Map(model, cuentaEntity);

            this._cuentaDomainRepository.UpdateSync(cuentaEntity);

            return this._mapper.Map<CuentaModel>(cuentaEntity);
        }

        public bool DeleteCuenta(int id)
        {
            CuentaEntity cuentaEntity = this._cuentaDomainRepository
                .FirstOrDefaultSync(x => x.Id == id);

            if (cuentaEntity == null)
                throw new CustomException(ExceptionSettings.NOT_FOUND);

            this._cuentaDomainRepository.RemoveSync(cuentaEntity);
            return true;
        }

        public PagedCollection<CuentaModel> GetAllCuentas(int offset, int limit)
        {
            PagedCollection<CuentaEntity> cuentaList = new PagedCollection<CuentaEntity>();
            List<string> navigationProperties = new List<string>();

            cuentaList = this._cuentaDomainRepository
                .GetPaginWhereSync(x => true, offset, limit, navigationProperties);

            return new PagedCollection<CuentaModel>()
            {
                Limit = cuentaList.Limit,
                Offset = cuentaList.Offset,
                Size = cuentaList.Size,
                Items = this._mapper.Map<CuentaModel[]>(cuentaList.Items)
            };
        }

        public CuentaModel GetCuentaById(int id)
        {
            CuentaEntity cuentaEntity = this._cuentaDomainRepository
                .FirstOrDefaultSync(x => x.Id == id);

            if (cuentaEntity == null)
                throw new CustomException(ExceptionSettings.NOT_FOUND);

            return this._mapper.Map<CuentaModel>(cuentaEntity);
        }
    }
}
