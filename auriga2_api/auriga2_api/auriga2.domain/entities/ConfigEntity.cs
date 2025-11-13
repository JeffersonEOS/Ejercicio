namespace auriga2.domain.entities;
public class ConfigEntity
{ 
    public System.Int32 Id { get; set; }
    public System.String Key { get; set; }
    public System.String Value { get; set; }
    public System.String LabelName { get; set; }
    public System.DateTime CreateDate { get; set; }
    public System.String UserCreatedAt { get; set; }
    public System.Boolean IsActive { get; set; }
    public System.Boolean IsDelete { get; set; }
    public System.String? UserUpdatedAt { get; set; }
    public System.DateTime? UpdateDate { get; set; }
    public System.String? Description { get; set; }
}