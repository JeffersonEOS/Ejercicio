using auriga2.domain.entities;
using auriga2.domain.models;
using auriga2.infraestructure.application.models;
using auriga2.infraestructure.util;
using auriga2.infraestructure.util.exceptions;

namespace auriga2.infraestructure.application
{
    public partial class ApplicationService : IApplicationService
    {
        public BancoModel CreateBanco(BancoModel model)
        {
            BancoEntity banco = this._mapper.Map<BancoEntity>(model);
            this._bancoDomainRepository.AddSync(banco);
            return this._mapper.Map<BancoModel>(banco);
        }

        public BancoModel UpdateBanco(BancoModel model)
        {
            BancoEntity bancoEntity = this._bancoDomainRepository
                .FirstOrDefaultSync(x => x.Id == model.Id);

            if (bancoEntity == null)
                throw new CustomException(ExceptionSettings.NOT_FOUND);

            bancoEntity = this._mapper.Map(model, bancoEntity);

            this._bancoDomainRepository.UpdateSync(bancoEntity);

            return this._mapper.Map<BancoModel>(bancoEntity);
        }

        public bool DeleteBanco(int id)
        {
            BancoEntity bancoEntity = this._bancoDomainRepository
                .FirstOrDefaultSync(x => x.Id == id);

            if (bancoEntity == null)
                throw new CustomException(ExceptionSettings.NOT_FOUND);

            this._bancoDomainRepository.RemoveSync(bancoEntity);
            return true;
        }

        public PagedCollection<BancoModel> GetAllBancos(int offset, int limit)
        {
            PagedCollection<BancoEntity> bancoList = new PagedCollection<BancoEntity>();
            List<string> navigationProperties = new List<string>();

            bancoList = this._bancoDomainRepository
                .GetPaginWhereSync(x => true, offset, limit, navigationProperties);

            return new PagedCollection<BancoModel>()
            {
                Limit = bancoList.Limit,
                Offset = bancoList.Offset,
                Size = bancoList.Size,
                Items = this._mapper.Map<BancoModel[]>(bancoList.Items)
            };
        }

        public BancoModel GetBancoById(int id)
        {
            BancoEntity bancoEntity = this._bancoDomainRepository
                .FirstOrDefaultSync(x => x.Id == id);

            if (bancoEntity == null)
                throw new CustomException(ExceptionSettings.NOT_FOUND);

            return this._mapper.Map<BancoModel>(bancoEntity);
        }
    }
}
