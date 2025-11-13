namespace auriga2.infraestructure.application.models;

public class UserDemoModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<string> Roles { get; set; }
}