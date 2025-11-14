using auriga2.domain.entities;
using auriga2.domain.models;
using auriga2.infraestructure.application.models;
using auriga2.infraestructure.util;
using auriga2.infraestructure.util.exceptions;

namespace auriga2.infraestructure.application
{
    public partial class ApplicationService : IApplicationService
    {
        public TransaccionModel CreateTransaccion(TransaccionModel model)
        {
            TransaccionEntity transaccion = this._mapper.Map<TransaccionEntity>(model);
            this._transaccionDomainRepository.AddSync(transaccion);
            return this._mapper.Map<TransaccionModel>(transaccion);
        }

        public TransaccionModel UpdateTransaccion(TransaccionModel model)
        {
            TransaccionEntity transaccionEntity = this._transaccionDomainRepository
                .FirstOrDefaultSync(x => x.Id == model.Id);

            if (transaccionEntity == null)
                throw new CustomException(ExceptionSettings.NOT_FOUND);

            // mapear solo los cambios del Model → Entity existente
            transaccionEntity = this._mapper.Map(model, transaccionEntity);

            this._transaccionDomainRepository.UpdateSync(transaccionEntity);

            return this._mapper.Map<TransaccionModel>(transaccionEntity);
        }

        public bool DeleteTransaccion(int id)
        {
            TransaccionEntity transaccionEntity = this._transaccionDomainRepository
                .FirstOrDefaultSync(x => x.Id == id);

            if (transaccionEntity == null)
                throw new CustomException(ExceptionSettings.NOT_FOUND);

            this._transaccionDomainRepository.RemoveSync(transaccionEntity);
            return true;
        }

        public PagedCollection<TransaccionModel> GetAllTransacciones(int offset, int limit)
        {
            PagedCollection<TransaccionEntity> transaccionList = new PagedCollection<TransaccionEntity>();
            List<string> navigationProperties = new List<string>();

            transaccionList = this._transaccionDomainRepository
                .GetPaginWhereSync(x => true, offset, limit, navigationProperties);

            return new PagedCollection<TransaccionModel>()
            {
                Limit = transaccionList.Limit,
                Offset = transaccionList.Offset,
                Size = transaccionList.Size,
                Items = this._mapper.Map<TransaccionModel[]>(transaccionList.Items)
            };
        }

        public TransaccionModel GetTransaccionById(int id)
        {
            TransaccionEntity transaccionEntity = this._transaccionDomainRepository
                .FirstOrDefaultSync(x => x.Id == id);

            if (transaccionEntity == null)
                throw new CustomException(ExceptionSettings.NOT_FOUND);

            return this._mapper.Map<TransaccionModel>(transaccionEntity);
        }
    }
}
