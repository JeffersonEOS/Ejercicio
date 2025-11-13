using auriga2.domain.models;
using auriga2.domain.entities;
using auriga2.infraestructure.util;
using auriga2.infraestructure.util.exceptions;
using auriga2.infraestructure.application.models;
namespace auriga2.infraestructure.application;
public partial class ApplicationService : IApplicationService
{ 
    public ConfigModel CreateConfig(ConfigModel configModel) 
    {
        ConfigEntity configEntity = this._mapper.Map<ConfigEntity>(configModel);
        this._configDomainRepository.AddSync(configEntity);
        return this._mapper.Map<ConfigModel>(configEntity);
    }
    public ConfigModel UpdateConfig(ConfigModel configModel)
    {
        ConfigEntity configEntity = this._configDomainRepository.FirstOrDefaultSync(x => x.Id == configModel.Id);
        if (null == configEntity) throw new CustomException(ExceptionSettings.NOT_FOUND);
        configEntity = this._mapper.Map(configModel, configEntity);
        this._configDomainRepository.UpdateSync(configEntity);
        return this._mapper.Map<ConfigModel>(configEntity);
    }
    public bool DeleteConfig(System.Int32 id)
    {
        ConfigEntity configEntity = this._configDomainRepository.FirstOrDefaultSync(x => x.Id == id);
        if (null == configEntity) throw new CustomException(ExceptionSettings.NOT_FOUND);
        this._configDomainRepository.RemoveSync(configEntity);
        return true;
    }
    public PagedCollection<ConfigModel> GetAllConfigModels(int offset, int limit)
    {
        PagedCollection<ConfigEntity> configEntityList = new PagedCollection<ConfigEntity>();
        List<string> navigationsProperties = new List<string>();
        configEntityList = this._configDomainRepository.GetPaginWhereSync(x => true, offset, limit, navigationsProperties);
        return new PagedCollection<ConfigModel>()
        {
            Limit = configEntityList.Limit,
            Offset = configEntityList.Offset,
            Size = configEntityList.Size,
            Items = this._mapper.Map<ConfigModel[]>(configEntityList.Items)
        };
    }
    public PagedCollection<ConfigModel> GetConfigModelsByParam(string param)
    {
        int offset = 0;
        int limit = 20;
        PagedCollection<ConfigEntity> configEntityList = new PagedCollection<ConfigEntity>();
        List<string> navigationsProperties = new List<string>();
        configEntityList = this._configDomainRepository.GetPaginWhereSync(x => true && (x.Key.Contains(param) || x.Value.Contains(param) || x.LabelName.Contains(param) || x.UserCreatedAt.Contains(param) || x.UserUpdatedAt.Contains(param) || x.Description.Contains(param) ), offset, limit, navigationsProperties);
        return new PagedCollection<ConfigModel>()
        {
            Limit = configEntityList.Limit,
            Offset = configEntityList.Offset,
            Size = configEntityList.Size,
            Items = this._mapper.Map<ConfigModel[]>(configEntityList.Items)
        };
    }
}