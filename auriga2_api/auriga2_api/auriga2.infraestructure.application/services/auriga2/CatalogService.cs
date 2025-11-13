using auriga2.domain.models;
using auriga2.domain.entities;
using auriga2.infraestructure.util;
using auriga2.infraestructure.util.exceptions;
using auriga2.infraestructure.application.models;
namespace auriga2.infraestructure.application;
public partial class ApplicationService : IApplicationService
{ 
    public CatalogModel CreateCatalog(CatalogModel catalogModel) 
    {
        CatalogEntity catalogEntity = this._mapper.Map<CatalogEntity>(catalogModel);
        this._catalogDomainRepository.AddSync(catalogEntity);
        return this._mapper.Map<CatalogModel>(catalogEntity);
    }
    public CatalogModel UpdateCatalog(CatalogModel catalogModel)
    {
        CatalogEntity catalogEntity = this._catalogDomainRepository.FirstOrDefaultSync(x => x.Id == catalogModel.Id);
        if (null == catalogEntity) throw new CustomException(ExceptionSettings.NOT_FOUND);
        catalogEntity = this._mapper.Map(catalogModel, catalogEntity);
        this._catalogDomainRepository.UpdateSync(catalogEntity);
        return this._mapper.Map<CatalogModel>(catalogEntity);
    }
    public bool DeleteCatalog(System.Int32 id)
    {
        CatalogEntity catalogEntity = this._catalogDomainRepository.FirstOrDefaultSync(x => x.Id == id);
        if (null == catalogEntity) throw new CustomException(ExceptionSettings.NOT_FOUND);
        this._catalogDomainRepository.RemoveSync(catalogEntity);
        return true;
    }
    public PagedCollection<CatalogModel> GetAllCatalogModels(int offset, int limit)
    {
        PagedCollection<CatalogEntity> catalogEntityList = new PagedCollection<CatalogEntity>();
        List<string> navigationsProperties = new List<string>();
        catalogEntityList = this._catalogDomainRepository.GetPaginWhereSync(x => true, offset, limit, navigationsProperties);
        return new PagedCollection<CatalogModel>()
        {
            Limit = catalogEntityList.Limit,
            Offset = catalogEntityList.Offset,
            Size = catalogEntityList.Size,
            Items = this._mapper.Map<CatalogModel[]>(catalogEntityList.Items)
        };
    }
    public PagedCollection<CatalogModel> GetCatalogModelsByParam(string param)
    {
        int offset = 0;
        int limit = 20;
        PagedCollection<CatalogEntity> catalogEntityList = new PagedCollection<CatalogEntity>();
        List<string> navigationsProperties = new List<string>();
        catalogEntityList = this._catalogDomainRepository.GetPaginWhereSync(x => true && (x.Key.Contains(param) || x.Name.Contains(param) || x.UserCreatedAt.Contains(param) || x.UserUpdatedAt.Contains(param) || x.Description.Contains(param) ), offset, limit, navigationsProperties);
        return new PagedCollection<CatalogModel>()
        {
            Limit = catalogEntityList.Limit,
            Offset = catalogEntityList.Offset,
            Size = catalogEntityList.Size,
            Items = this._mapper.Map<CatalogModel[]>(catalogEntityList.Items)
        };
    }
}