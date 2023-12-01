using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskАndProjectManagementSystem.Application;
using TaskАndProjectManagementSystem.Application.Constants;
using TaskАndProjectManagementSystem.Application.Contracts.Identity;
using TaskАndProjectManagementSystem.Application.Model.Identity;
using TaskАndProjectManagementSystem.Domain;

namespace TaskАndProjectManagementSystem.Identety.Services;
public class AuthService : IAuthService
{
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;
    private JwtSettings _jwtSettings;
    public AuthService(UserManager<User>  userManager, SignInManager<User> signInManager,IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _jwtSettings = (JwtSettings?)jwtSettings;
        _signInManager = signInManager; 

    }
    public async Task<AuthResponce> Login(AuthRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email); 
        
        if (user == null)
        {
            throw new Exception($"Email '{request.Email} not exis");
        }

        var result = await _signInManager.PasswordSignInAsync(user, request.Password, isPersistent: false, lockoutOnFailure: false);
        if (!result.Succeeded)
        {
            throw new Exception($"Credentials for '{request.Email} aren't valid'.");
        }
        JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

        var responce = new AuthResponce()
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = request.Email,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
        };
        return responce;
    }

    public async Task<RegistrationResponce> Registration(RegistrationRequest request)
    {
        var existUser = await _userManager.FindByNameAsync(request.UserName);
        if (existUser != null)
        {
            throw new Exception($"User '{request.UserName}' alredi exist");
        }

        var existEmail = await _userManager.FindByEmailAsync(request.Email);
        if (existEmail == null)
            throw new Exception($"User email '{request.Email}' alredi exist");

        var user = new User()
        {
            UserName = request.UserName,    
            Email = request.Email,  
            FirstName = request.FirstName,
            LastName = request.LastName,
            EmailConfirmed = true
        };

            var result = await _userManager.CreateAsync(user, user.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                var responce = new RegistrationResponce() {UserId = user.Id };
                return responce;
            }
            else
            {
                throw new Exception($"{result.Errors}");
            }
    }

    private async Task<JwtSecurityToken> GenerateToken(User user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var roleClaims = new List<Claim>();

        for (int i = 0; i < roles.Count; i++)
        {
            roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
        }

        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id)
        }
        .Union(userClaims)
        .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials);

        return jwtSecurityToken;
    }
}
