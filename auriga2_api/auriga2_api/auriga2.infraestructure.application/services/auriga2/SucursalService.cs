using auriga2.domain.entities;
using auriga2.domain.models;
using auriga2.infraestructure.application.models;
using auriga2.infraestructure.util;
using auriga2.infraestructure.util.exceptions;

namespace auriga2.infraestructure.application
{
    public partial class ApplicationService : IApplicationService
    {
        public SucursalModel CreateSucursal(SucursalModel model)
        {
            SucursalEntity sucursal = this._mapper.Map<SucursalEntity>(model);
            this._sucursalDomainRepository.AddSync(sucursal);
            return this._mapper.Map<SucursalModel>(sucursal);
        }

        public SucursalModel UpdateSucursal(SucursalModel model)
        {
            SucursalEntity sucursalEntity = this._sucursalDomainRepository
                .FirstOrDefaultSync(x => x.Id == model.Id);

            if (sucursalEntity == null)
                throw new CustomException(ExceptionSettings.NOT_FOUND);

            // Mapear solo cambios
            sucursalEntity = this._mapper.Map(model, sucursalEntity);

            this._sucursalDomainRepository.UpdateSync(sucursalEntity);

            return this._mapper.Map<SucursalModel>(sucursalEntity);
        }

        public bool DeleteSucursal(int id)
        {
            SucursalEntity sucursalEntity = this._sucursalDomainRepository
                .FirstOrDefaultSync(x => x.Id == id);

            if (sucursalEntity == null)
                throw new CustomException(ExceptionSettings.NOT_FOUND);

            this._sucursalDomainRepository.RemoveSync(sucursalEntity);
            return true;
        }

        public PagedCollection<SucursalModel> GetAllSucursales(int offset, int limit)
        {
            PagedCollection<SucursalEntity> sucursalList = new PagedCollection<SucursalEntity>();
            List<string> navigationProperties = new List<string>();

            sucursalList = this._sucursalDomainRepository
                .GetPaginWhereSync(x => true, offset, limit, navigationProperties);

            return new PagedCollection<SucursalModel>()
            {
                Limit = sucursalList.Limit,
                Offset = sucursalList.Offset,
                Size = sucursalList.Size,
                Items = this._mapper.Map<SucursalModel[]>(sucursalList.Items)
            };
        }

        public SucursalModel GetSucursalById(int id)
        {
            SucursalEntity sucursalEntity = this._sucursalDomainRepository
                .FirstOrDefaultSync(x => x.Id == id);

            if (sucursalEntity == null)
                throw new CustomException(ExceptionSettings.NOT_FOUND);

            return this._mapper.Map<SucursalModel>(sucursalEntity);
        }
    }
}
