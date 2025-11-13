using auriga2.domain.models;
using auriga2.infraestructure.application.models;
namespace auriga2.infraestructure.application;
public partial interface IApplicationService
{ 
    ConfigModel CreateConfig(ConfigModel configModel); 
    ConfigModel UpdateConfig(ConfigModel configModel); 
    bool DeleteConfig(System.Int32 id); 
    PagedCollection<ConfigModel> GetAllConfigModels(int offset, int limit);
    PagedCollection<ConfigModel> GetConfigModelsByParam(string param);
}