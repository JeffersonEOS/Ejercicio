namespace auriga2.infraestructure.application.models;
public class UserRoleModel
{ 
    public int? Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public DateTime CreateDate { get; set; }
    public System.String UserCreatedAt { get; set; }
    public System.Boolean IsActive { get; set; }
    public System.Boolean IsDelete { get; set; }
    public System.String? UserUpdatedAt { get; set; }
    public System.DateTime? UpdateDate { get; set; }
}