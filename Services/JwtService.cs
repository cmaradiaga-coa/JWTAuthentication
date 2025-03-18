using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiDemo.Data;
using WebApiDemo.Handlers;
using WebApiDemo.Models.Api;

namespace WebApiDemo.Services;

public class JwtService
{
    private readonly AppDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public JwtService(AppDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    //! Para aceptar el login request y devolver un token JWT:
    public async Task<LoginResponseModel?> Authenticate(LoginRequestModel request)
    {
        //? verificar si el nombre de usuario o la contraseña están vacíos:
        if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
            return null;

        //? verificar si el usuario existe y si la contraseña es correcta: (PasswordHashHandler.VerifyPassword) esta función se encuentra en la clase PasswordHashHandler.    
        var userAccount = await _dbContext.UserAccounts.FirstOrDefaultAsync(x => x.UserName == request.UserName);
        if (userAccount is null || !PasswordHashHandler.VerifyPassword(request.Password, userAccount.Password!))
            return null;


        var issuer = _configuration["JwtConfig:Issuer"];
        var audience = _configuration["JwtConfig:Audience"];
        var key = _configuration["JwtConfig:Key"];
        var tokenValidityMins = _configuration.GetValue<int>("JwtConfig:TokenValidityMins");
        var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(tokenValidityMins);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, request.UserName)
            }),
            Expires = tokenExpiryTimeStamp,
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                SecurityAlgorithms.HmacSha512Signature),
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var accessToken = tokenHandler.WriteToken(securityToken);

        return new LoginResponseModel
        {
            AccessToken = accessToken,
            UserName = request.UserName,
            ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.UtcNow).TotalSeconds
        };
    }
}
