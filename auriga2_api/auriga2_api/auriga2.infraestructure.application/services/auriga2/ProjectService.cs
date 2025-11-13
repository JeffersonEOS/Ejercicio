using auriga2.domain.models;
using auriga2.domain.entities;
using auriga2.infraestructure.util;
using auriga2.infraestructure.util.exceptions;
using auriga2.infraestructure.application.models;
namespace auriga2.infraestructure.application;
public partial class ApplicationService : IApplicationService
{ 
    public ProjectModel CreateProject(ProjectModel projectModel) 
    {
        ProjectEntity projectEntity = this._mapper.Map<ProjectEntity>(projectModel);
        this._projectDomainRepository.AddSync(projectEntity);
        return this._mapper.Map<ProjectModel>(projectEntity);
    }
    public ProjectModel UpdateProject(ProjectModel projectModel)
    {
        ProjectEntity projectEntity = this._projectDomainRepository.FirstOrDefaultSync(x => x.Id == projectModel.Id);
        if (null == projectEntity) throw new CustomException(ExceptionSettings.NOT_FOUND);
        projectEntity = this._mapper.Map(projectModel, projectEntity);
        this._projectDomainRepository.UpdateSync(projectEntity);
        return this._mapper.Map<ProjectModel>(projectEntity);
    }
    public bool DeleteProject(System.Int32 id)
    {
        ProjectEntity projectEntity = this._projectDomainRepository.FirstOrDefaultSync(x => x.Id == id);
        if (null == projectEntity) throw new CustomException(ExceptionSettings.NOT_FOUND);
        this._projectDomainRepository.RemoveSync(projectEntity);
        return true;
    }
    public PagedCollection<ProjectModel> GetAllProjectModels(int offset, int limit)
    {
        PagedCollection<ProjectEntity> projectEntityList = new PagedCollection<ProjectEntity>();
        List<string> navigationsProperties = new List<string>();
        projectEntityList = this._projectDomainRepository.GetPaginWhereSync(x => true, offset, limit, navigationsProperties);
        return new PagedCollection<ProjectModel>()
        {
            Limit = projectEntityList.Limit,
            Offset = projectEntityList.Offset,
            Size = projectEntityList.Size,
            Items = this._mapper.Map<ProjectModel[]>(projectEntityList.Items)
        };
    }
    public PagedCollection<ProjectModel> GetProjectModelsByParam(string param)
    {
        int offset = 0;
        int limit = 20;
        PagedCollection<ProjectEntity> projectEntityList = new PagedCollection<ProjectEntity>();
        List<string> navigationsProperties = new List<string>();
        projectEntityList = this._projectDomainRepository.GetPaginWhereSync(x => true && (x.Name.Contains(param) || x.UrlZipProject.Contains(param) || x.UserCreatedAt.Contains(param) || x.Regenerates.Contains(param) || x.UserUpdatedAt.Contains(param) || x.PremiumName.Contains(param) || x.PremiumType.Contains(param) || x.ConnectionDb.Contains(param) || x.Description.Contains(param) ), offset, limit, navigationsProperties);
        return new PagedCollection<ProjectModel>()
        {
            Limit = projectEntityList.Limit,
            Offset = projectEntityList.Offset,
            Size = projectEntityList.Size,
            Items = this._mapper.Map<ProjectModel[]>(projectEntityList.Items)
        };
    }
}