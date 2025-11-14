using auriga2.domain.entities;
using auriga2.domain.models;
using auriga2.infraestructure.application.models;
using auriga2.infraestructure.util;
using auriga2.infraestructure.util.exceptions;

namespace auriga2.infraestructure.application
{
    public partial class ApplicationService : IApplicationService
    {
        public ClienteModel CreateCliente(ClienteModel model)
        {
            ClienteEntity cliente = this._mapper.Map<ClienteEntity>(model);
            this._clienteDomainRepository.AddSync(cliente);
            return this._mapper.Map<ClienteModel>(cliente);
        }

        public ClienteModel UpdateCliente(ClienteModel model)
        {
            ClienteEntity clienteEntity = this._clienteDomainRepository
                .FirstOrDefaultSync(x => x.Id == model.Id);

            if (clienteEntity == null)
                throw new CustomException(ExceptionSettings.NOT_FOUND);

            clienteEntity = this._mapper.Map(model, clienteEntity);

            this._clienteDomainRepository.UpdateSync(clienteEntity);

            return this._mapper.Map<ClienteModel>(clienteEntity);
        }

        public bool DeleteCliente(int id)
        {
            ClienteEntity clienteEntity = this._clienteDomainRepository
                .FirstOrDefaultSync(x => x.Id == id);

            if (clienteEntity == null)
                throw new CustomException(ExceptionSettings.NOT_FOUND);

            this._clienteDomainRepository.RemoveSync(clienteEntity);
            return true;
        }

        public PagedCollection<ClienteModel> GetAllClientes(int offset, int limit)
        {
            PagedCollection<ClienteEntity> clienteList = new PagedCollection<ClienteEntity>();
            List<string> navigationProperties = new List<string>();

            clienteList = this._clienteDomainRepository
                .GetPaginWhereSync(x => true, offset, limit, navigationProperties);

            return new PagedCollection<ClienteModel>()
            {
                Limit = clienteList.Limit,
                Offset = clienteList.Offset,
                Size = clienteList.Size,
                Items = this._mapper.Map<ClienteModel[]>(clienteList.Items)
            };
        }

        public ClienteModel GetClienteById(int id)
        {
            ClienteEntity clienteEntity = this._clienteDomainRepository
                .FirstOrDefaultSync(x => x.Id == id);

            if (clienteEntity == null)
                throw new CustomException(ExceptionSettings.NOT_FOUND);

            return this._mapper.Map<ClienteModel>(clienteEntity);
        }
    }
}
