using auriga2.domain.models;
using auriga2.infraestructure.application.models;
namespace auriga2.infraestructure.application;
public partial interface IApplicationService
{ 
    CatalogModel CreateCatalog(CatalogModel catalogModel); 
    CatalogModel UpdateCatalog(CatalogModel catalogModel); 
    bool DeleteCatalog(System.Int32 id); 
    PagedCollection<CatalogModel> GetAllCatalogModels(int offset, int limit);
    PagedCollection<CatalogModel> GetCatalogModelsByParam(string param);
}