using auriga2.domain.models;

using auriga2.infraestructure.util;
using auriga2.infraestructure.util.exceptions;
using auriga2.infraestructure.application.models;
using auriga2.domain.entities;
namespace auriga2.infraestructure.application;
public partial class ApplicationService : IApplicationService
{ 
    public UserModel CreateUser(UserModel userModel) 
    {
        UserEntity userEntity = this._mapper.Map<UserEntity>(userModel);
        this._userDomainRepository.AddSync(userEntity);
        return this._mapper.Map<UserModel>(userEntity);
    }

    public UserModel UpdateUser(UserModel userModel)
    {
        UserEntity userEntity = this._userDomainRepository.FirstOrDefaultSync(x => x.Id == userModel.Id);
        if (null == userEntity) throw new CustomException(ExceptionSettings.NOT_FOUND);
        userEntity = this._mapper.Map(userModel, userEntity);
        this._userDomainRepository.UpdateSync(userEntity);
        return this._mapper.Map<UserModel>(userEntity);
    }
    public bool DeleteUser(System.Int32 id)
    {
        UserEntity userEntity = this._userDomainRepository.FirstOrDefaultSync(x => x.Id == id);
        if (null == userEntity) throw new CustomException(ExceptionSettings.NOT_FOUND);
        this._userDomainRepository.RemoveSync(userEntity);
        return true;
    }
    public PagedCollection<UserModel> GetAllUserModels(int offset, int limit)
    {
        PagedCollection<UserEntity> userEntityList = new PagedCollection<UserEntity>();
        List<string> navigationsProperties = new List<string>();
        userEntityList = this._userDomainRepository.GetPaginWhereSync(x => true, offset, limit, navigationsProperties);
        return new PagedCollection<UserModel>()
        {
            Limit = userEntityList.Limit,
            Offset = userEntityList.Offset,
            Size = userEntityList.Size,
            Items = this._mapper.Map<UserModel[]>(userEntityList.Items)
        };
    }
    public UserRoleModel AssignRoleToUser(UserRoleModel userRoleModel)
    {
        UserRoleEntity userRoleEntity = this._mapper.Map<UserRoleEntity>(userRoleModel);
   
        UserEntity user = this._userDomainRepository.FirstOrDefaultSync(x => x.Id == userRoleEntity.UserId);
    
        if (user == null)
            throw new CustomException("El usuario especificado no existe.");

        var role = this._roleDomainRepository.FirstOrDefaultSync(x => x.Id == userRoleEntity.RoleId);
        if (role == null)
            throw new CustomException("El rol especificado no existe.");

        this._userRoleDomainRepository.AddSync(userRoleEntity);

        return this._mapper.Map<UserRoleModel>(userRoleEntity);
    }
    public UserModel CreateUserAndAssignRole(UserModel userModel, int roleId)
    {
        // 1. Crear el usuario
        UserEntity userEntity = this._mapper.Map<UserEntity>(userModel);
        userEntity.IsDelete = false;

        // 2. Validar que el rol exista
        RoleEntity roleEntity = this._roleDomainRepository.FirstOrDefaultSync(x => x.Id == roleId);
        if (roleEntity == null)
            throw new CustomException($"El rol con Id {roleId} no existe.");

        // 3. Guardar el usuario primero (para obtener su Id)
        this._userDomainRepository.AddSync(userEntity);

        // 4. Crear la relación UserRoleEntity
        UserRoleEntity userRoleEntity = new UserRoleEntity
        {
            UserId = userEntity.Id,
            RoleId = roleId,
            IsActive = true,
            IsDelete = false,
            CreateDate = DateTime.Now,
            UserCreatedAt = userEntity.UserCreatedAt
        };

        // 5. Guardar la relación usuario-rol
        this._userRoleDomainRepository.AddSync(userRoleEntity);

        // 6. Construir el modelo a devolver
        UserModel userResult = this._mapper.Map<UserModel>(userEntity);

        userResult.UserRoleList = new List<UserRoleModel>
    {
        new UserRoleModel
        {
            UserId = userEntity.Id,
            RoleId = roleId,
            IsActive = true,
            IsDelete = false,
            CreateDate = userRoleEntity.CreateDate,
            UserCreatedAt = userEntity.UserCreatedAt
        }
    };

        return userResult;
    }


    public PagedCollection<UserModel> GetUserModelsByParam(string param)
    {
        int offset = 0;
        int limit = 20;
        PagedCollection<UserEntity> userEntityList = new PagedCollection<UserEntity>();
        List<string> navigationsProperties = new List<string>();
        userEntityList = this._userDomainRepository.GetPaginWhereSync(x => true && (x.FirstSurname.Contains(param) || x.FirstName.Contains(param) || x.UserCreatedAt.Contains(param) || x.DataPremium.Contains(param) || x.UserUpdatedAt.Contains(param) || x.ProviderId.Contains(param) || x.SecondName.Contains(param) || x.Email.Contains(param) || x.Identification.Contains(param) || x.SecondSurname.Contains(param) || x.GenderKey.Contains(param) || x.Cellphone.Contains(param) || x.Password.Contains(param) || x.Country.Contains(param) || x.CountryCode.Contains(param) || x.Region.Contains(param) || x.RegionName.Contains(param) || x.City.Contains(param) || x.Timezone.Contains(param) || x.SubscriptionKey.Contains(param) ), offset, limit, navigationsProperties);
        return new PagedCollection<UserModel>()
        {
            Limit = userEntityList.Limit,
            Offset = userEntityList.Offset,
            Size = userEntityList.Size,
            Items = this._mapper.Map<UserModel[]>(userEntityList.Items)
        };
    }
}