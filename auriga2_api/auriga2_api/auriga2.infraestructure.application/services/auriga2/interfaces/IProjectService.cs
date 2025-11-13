using auriga2.domain.models;
using auriga2.infraestructure.application.models;
namespace auriga2.infraestructure.application;
public partial interface IApplicationService
{ 
    ProjectModel CreateProject(ProjectModel projectModel); 
    ProjectModel UpdateProject(ProjectModel projectModel); 
    bool DeleteProject(System.Int32 id); 
    PagedCollection<ProjectModel> GetAllProjectModels(int offset, int limit);
    PagedCollection<ProjectModel> GetProjectModelsByParam(string param);
}