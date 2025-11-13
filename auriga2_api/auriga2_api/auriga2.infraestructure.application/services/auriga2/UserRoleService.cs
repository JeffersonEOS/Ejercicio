using auriga2.domain.models;
using auriga2.domain.entities;
using auriga2.infraestructure.util;
using auriga2.infraestructure.util.exceptions;
using auriga2.infraestructure.application.models;
namespace auriga2.infraestructure.application;
public partial class ApplicationService : IApplicationService
{ 
    public UserRoleModel CreateUserRole(UserRoleModel userRoleModel) 
    {
        UserRoleEntity userRoleEntity = this._mapper.Map<UserRoleEntity>(userRoleModel);
        this._userRoleDomainRepository.AddSync(userRoleEntity);
        return this._mapper.Map<UserRoleModel>(userRoleEntity);
    }
    public UserRoleModel UpdateUserRole(UserRoleModel userRoleModel)
    {
        UserRoleEntity userRoleEntity = this._userRoleDomainRepository.FirstOrDefaultSync(x => x.Id == userRoleModel.Id);
        if (null == userRoleEntity) throw new CustomException(ExceptionSettings.NOT_FOUND);
        userRoleEntity = this._mapper.Map(userRoleModel, userRoleEntity);
        this._userRoleDomainRepository.UpdateSync(userRoleEntity);
        return this._mapper.Map<UserRoleModel>(userRoleEntity);
    }
    public bool DeleteUserRole(System.Int32 id)
    {
        UserRoleEntity userRoleEntity = this._userRoleDomainRepository.FirstOrDefaultSync(x => x.Id == id);
        if (null == userRoleEntity) throw new CustomException(ExceptionSettings.NOT_FOUND);
        this._userRoleDomainRepository.RemoveSync(userRoleEntity);
        return true;
    }
    public PagedCollection<UserRoleModel> GetAllUserRoleModels(int offset, int limit)
    {
        PagedCollection<UserRoleEntity> userRoleEntityList = new PagedCollection<UserRoleEntity>();
        List<string> navigationsProperties = new List<string>();
        userRoleEntityList = this._userRoleDomainRepository.GetPaginWhereSync(x => true, offset, limit, navigationsProperties);
        return new PagedCollection<UserRoleModel>()
        {
            Limit = userRoleEntityList.Limit,
            Offset = userRoleEntityList.Offset,
            Size = userRoleEntityList.Size,
            Items = this._mapper.Map<UserRoleModel[]>(userRoleEntityList.Items)
        };
    }
    public PagedCollection<UserRoleModel> GetUserRoleModelsByParam(string param)
    {
        int offset = 0;
        int limit = 20;
        PagedCollection<UserRoleEntity> userRoleEntityList = new PagedCollection<UserRoleEntity>();
        List<string> navigationsProperties = new List<string>();
        userRoleEntityList = this._userRoleDomainRepository.GetPaginWhereSync(x => true && (x.UserCreatedAt.Contains(param) || x.UserUpdatedAt.Contains(param) ), offset, limit, navigationsProperties);
        return new PagedCollection<UserRoleModel>()
        {
            Limit = userRoleEntityList.Limit,
            Offset = userRoleEntityList.Offset,
            Size = userRoleEntityList.Size,
            Items = this._mapper.Map<UserRoleModel[]>(userRoleEntityList.Items)
        };
    }
}