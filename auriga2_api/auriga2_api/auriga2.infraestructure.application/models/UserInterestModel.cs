namespace auriga2.infraestructure.application.models;
public class UserInterestModel
{ 
    public System.Int32? Id { get; set; }
    public System.Int32 UserId { get; set; }
    public System.String InterstKey { get; set; }
    public System.DateTime CreateDate { get; set; }
    public System.String UserCreatedAt { get; set; }
    public System.Boolean IsActive { get; set; }
    public System.Boolean IsDelete { get; set; }
    public System.String? UserUpdatedAt { get; set; }
    public System.DateTime? UpdateDate { get; set; }
}