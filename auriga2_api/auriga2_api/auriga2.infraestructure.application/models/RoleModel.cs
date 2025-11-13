namespace auriga2.infraestructure.application.models;
public class RoleModel
{ 
    public System.Int32? Id { get; set; }
    public System.String Key { get; set; }
    public System.String Name { get; set; }
    public System.DateTime CreateDate { get; set; }
    public System.String UserCreatedAt { get; set; }
    public System.Boolean IsActive { get; set; }
    public System.Boolean IsDelete { get; set; }
    public System.String? UserUpdatedAt { get; set; }
    public System.DateTime? UpdateDate { get; set; }
    public List<UserRoleModel>? UserRoleList { get; set; }
}