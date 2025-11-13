namespace auriga2.infraestructure.application.models;
public class UserModel
{ 
    public System.String FirstSurname { get; set; }
    public System.Int32? Id { get; set; }
    public System.String FirstName { get; set; }
    public System.Int32 PlanSupportHours { get; set; }
    public System.Int32 PackageSupportHours { get; set; }
    public System.DateTime CreateDate { get; set; }
    public System.String UserCreatedAt { get; set; }
    public System.Boolean IsActive { get; set; }
    public System.Boolean IsDelete { get; set; }
    public System.String? DataPremium { get; set; }
    public System.String? UserUpdatedAt { get; set; }
    public System.DateTime? UpdateDate { get; set; }
    public System.String? ProviderId { get; set; }
    public System.String? SecondName { get; set; }
    public System.String? Email { get; set; }
    public System.String? Identification { get; set; }
    public System.String? SecondSurname { get; set; }
    public System.String? GenderKey { get; set; }
    public System.DateTime? Birthdate { get; set; }
    public System.String? Cellphone { get; set; }
    public System.String? Password { get; set; }
    public System.String? Country { get; set; }
    public System.String? CountryCode { get; set; }
    public System.String? Region { get; set; }
    public System.String? RegionName { get; set; }
    public System.String? City { get; set; }
    public System.Double? Latitude { get; set; }
    public System.Double? Longitude { get; set; }
    public System.String? Timezone { get; set; }
    public System.String? SubscriptionKey { get; set; }
    public List<UserRoleModel>? UserRoleList { get; set; }
    public List<ProjectModel>? ProjectList { get; set; }
    public List<UserInterestModel>? UserInterestList { get; set; }
}