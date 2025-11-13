namespace auriga2.infraestructure.application.models;
public class ProjectModel
{ 
    public System.Int32? Id { get; set; }
    public System.Int32 UserId { get; set; }
    public System.Guid Key { get; set; }
    public System.String Name { get; set; }
    public System.String UrlZipProject { get; set; }
    public System.Int32 TotalRegenerations { get; set; }
    public System.DateTime CreateDate { get; set; }
    public System.String UserCreatedAt { get; set; }
    public System.Boolean IsActive { get; set; }
    public System.Boolean IsDelete { get; set; }
    public System.String? Regenerates { get; set; }
    public System.String? UserUpdatedAt { get; set; }
    public System.DateTime? UpdateDate { get; set; }
    public System.String? PremiumName { get; set; }
    public System.String? PremiumType { get; set; }
    public System.String? ConnectionDb { get; set; }
    public System.String? Description { get; set; }
}