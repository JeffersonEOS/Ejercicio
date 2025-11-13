using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using auriga2.infraestructure.application.models;
using auriga2.infraestructure.application.models.requests;
using auriga2.infraestructure.util;
using auriga2.infraestructure.util.exceptions;
using Microsoft.IdentityModel.Tokens;

namespace auriga2.infraestructure.application;

public partial class ApplicationService : IApplicationService
{

    private UserDemoModel GetMockUserDb(string email, string password)
    {
        List<UserDemoModel> usersMock = new List<UserDemoModel>();
        usersMock.Add(new UserDemoModel()
        {
            Id = 1,
            Email = "afvs@gmail.com",
            Password = "12345678",
            Roles = new List<string>(){"ADMIN","EDIT"}
        });
        usersMock.Add(new UserDemoModel()
        {
            Id = 2,
            Email = "test@gmail.com",
            Password = "12345678",
            Roles = new List<string>(){"ADMIN"}
        });

        return usersMock.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));
    }
    
    public LoginResponseModel Login(LoginRequestModel loginRequestModel)
    {
        // TODO CHANGE BY QUERY TO THE DATABASE WITH YOUR SECURITIES
        UserDemoModel user = this.GetMockUserDb(loginRequestModel.Email, loginRequestModel.Password);
        if (user == null)
            throw new CustomException(ExceptionSettings.NOT_FOUND);
        List<Claim> userClaims = this.GenerateUserClaims(user);
        string token = this.GenerateUserToken(userClaims);
        return new LoginResponseModel
        {
            Token = token,
        };
    }

    private string GenerateUserToken(List<Claim> userClaims)
    {
        byte[] key = Encoding.ASCII.GetBytes(this._tokenKey);
        JwtSecurityTokenHandler tokenHandler = new();
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(userClaims),
            NotBefore = DateTime.UtcNow.AddMinutes(-5),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        SecurityToken? token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    
    private List<Claim> GenerateUserClaims(UserDemoModel user)
    {
        List<Claim> claims = new List<Claim>()
        {
            new("id", user.Id.ToString()),
            new("username", user.Email),
        };
        claims.AddRange(user.Roles.Select(x => new Claim("role", x)));
        return claims;
    }
}