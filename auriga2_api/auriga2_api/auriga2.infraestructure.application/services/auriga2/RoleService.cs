using auriga2.domain.models;
using auriga2.domain.entities;
using auriga2.infraestructure.util;
using auriga2.infraestructure.util.exceptions;
using auriga2.infraestructure.application.models;
namespace auriga2.infraestructure.application;
public partial class ApplicationService : IApplicationService
{ 
    public RoleModel CreateRole(RoleModel roleModel) 
    {
        RoleEntity roleEntity = this._mapper.Map<RoleEntity>(roleModel);
        this._roleDomainRepository.AddSync(roleEntity);
        return this._mapper.Map<RoleModel>(roleEntity);
    }
    public RoleModel UpdateRole(RoleModel roleModel)
    {
        RoleEntity roleEntity = this._roleDomainRepository.FirstOrDefaultSync(x => x.Id == roleModel.Id);
        if (null == roleEntity) throw new CustomException(ExceptionSettings.NOT_FOUND);
        roleEntity = this._mapper.Map(roleModel, roleEntity);
        this._roleDomainRepository.UpdateSync(roleEntity);
        return this._mapper.Map<RoleModel>(roleEntity);
    }
    public bool DeleteRole(System.Int32 id)
    {
        RoleEntity roleEntity = this._roleDomainRepository.FirstOrDefaultSync(x => x.Id == id);
        if (null == roleEntity) throw new CustomException(ExceptionSettings.NOT_FOUND);
        this._roleDomainRepository.RemoveSync(roleEntity);
        return true;
    }
    public PagedCollection<RoleModel> GetAllRoleModels(int offset, int limit)
    {
        PagedCollection<RoleEntity> roleEntityList = new PagedCollection<RoleEntity>();
        List<string> navigationsProperties = new List<string>();
        roleEntityList = this._roleDomainRepository.GetPaginWhereSync(x => true, offset, limit, navigationsProperties);
        return new PagedCollection<RoleModel>()
        {
            Limit = roleEntityList.Limit,
            Offset = roleEntityList.Offset,
            Size = roleEntityList.Size,
            Items = this._mapper.Map<RoleModel[]>(roleEntityList.Items)
        };
    }
    public PagedCollection<RoleModel> GetRoleModelsByParam(string param)
    {
        int offset = 0;
        int limit = 20;
        PagedCollection<RoleEntity> roleEntityList = new PagedCollection<RoleEntity>();
        List<string> navigationsProperties = new List<string>();
        roleEntityList = this._roleDomainRepository.GetPaginWhereSync(x => true && (x.Key.Contains(param) || x.Name.Contains(param) || x.UserCreatedAt.Contains(param) || x.UserUpdatedAt.Contains(param) ), offset, limit, navigationsProperties);
        return new PagedCollection<RoleModel>()
        {
            Limit = roleEntityList.Limit,
            Offset = roleEntityList.Offset,
            Size = roleEntityList.Size,
            Items = this._mapper.Map<RoleModel[]>(roleEntityList.Items)
        };
    }
}