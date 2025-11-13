using auriga2.domain.models;
using auriga2.domain.entities;
using auriga2.infraestructure.util;
using auriga2.infraestructure.util.exceptions;
using auriga2.infraestructure.application.models;
namespace auriga2.infraestructure.application;
public partial class ApplicationService : IApplicationService
{ 
    public UserInterestModel CreateUserInterest(UserInterestModel userInterestModel) 
    {
        UserInterestEntity userInterestEntity = this._mapper.Map<UserInterestEntity>(userInterestModel);
        this._userInterestDomainRepository.AddSync(userInterestEntity);
        return this._mapper.Map<UserInterestModel>(userInterestEntity);
    }
    public UserInterestModel UpdateUserInterest(UserInterestModel userInterestModel)
    {
        UserInterestEntity userInterestEntity = this._userInterestDomainRepository.FirstOrDefaultSync(x => x.Id == userInterestModel.Id);
        if (null == userInterestEntity) throw new CustomException(ExceptionSettings.NOT_FOUND);
        userInterestEntity = this._mapper.Map(userInterestModel, userInterestEntity);
        this._userInterestDomainRepository.UpdateSync(userInterestEntity);
        return this._mapper.Map<UserInterestModel>(userInterestEntity);
    }
    public bool DeleteUserInterest(System.Int32 id)
    {
        UserInterestEntity userInterestEntity = this._userInterestDomainRepository.FirstOrDefaultSync(x => x.Id == id);
        if (null == userInterestEntity) throw new CustomException(ExceptionSettings.NOT_FOUND);
        this._userInterestDomainRepository.RemoveSync(userInterestEntity);
        return true;
    }
    public PagedCollection<UserInterestModel> GetAllUserInterestModels(int offset, int limit)
    {
        PagedCollection<UserInterestEntity> userInterestEntityList = new PagedCollection<UserInterestEntity>();
        List<string> navigationsProperties = new List<string>();
        userInterestEntityList = this._userInterestDomainRepository.GetPaginWhereSync(x => true, offset, limit, navigationsProperties);
        return new PagedCollection<UserInterestModel>()
        {
            Limit = userInterestEntityList.Limit,
            Offset = userInterestEntityList.Offset,
            Size = userInterestEntityList.Size,
            Items = this._mapper.Map<UserInterestModel[]>(userInterestEntityList.Items)
        };
    }
    public PagedCollection<UserInterestModel> GetUserInterestModelsByParam(string param)
    {
        int offset = 0;
        int limit = 20;
        PagedCollection<UserInterestEntity> userInterestEntityList = new PagedCollection<UserInterestEntity>();
        List<string> navigationsProperties = new List<string>();
        userInterestEntityList = this._userInterestDomainRepository.GetPaginWhereSync(x => true && (x.InterstKey.Contains(param) || x.UserCreatedAt.Contains(param) || x.UserUpdatedAt.Contains(param) ), offset, limit, navigationsProperties);
        return new PagedCollection<UserInterestModel>()
        {
            Limit = userInterestEntityList.Limit,
            Offset = userInterestEntityList.Offset,
            Size = userInterestEntityList.Size,
            Items = this._mapper.Map<UserInterestModel[]>(userInterestEntityList.Items)
        };
    }
}