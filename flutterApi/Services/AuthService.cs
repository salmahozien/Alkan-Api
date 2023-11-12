using flutterApi.DTOs.Register;
using flutterApi.DTOs.User;
using flutterApi.Helpers;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.DTOs;
using login.Models;
using Mapster;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace flutterApi.Services
{
    public class AuthService : BaseRepository<User>, IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;



        public AuthService(ApplicationDBContext Context, UserManager<User> userManager, IOptions<JWT> jwt, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager) : base(Context)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<AuthRegisterDto> Login(LoginDto model)
        {
            var UserReturn = new AuthRegisterDto();
          
           var user = await Find(x => x.PhoneNumber == model.PhoneNumber );
            if(user == null)
            {
                UserReturn.Message = "Failed Login Atempt";
                return UserReturn;
            }
         
       
          
           var user2= await _signInManager.UserManager.GetUserIdAsync(user);
           
             UserReturn = new AuthRegisterDto()
            {
               
                UserId = user2,
                PhoneNumber = model.PhoneNumber,
                
            };
           
            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            UserReturn.IsAuthenticated = true;

            UserReturn.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            UserReturn.PhoneNumber = user.PhoneNumber;
            
            UserReturn.ExpiresOn = jwtSecurityToken.ValidTo;
            UserReturn.Roles = rolesList.ToList();
            if (user.RefreshTokens.Any(t => t.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
                UserReturn.RefreshToken = activeRefreshToken.Token;
                UserReturn.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
            
                var jwtToken= await CreateJwtToken(user);
                UserReturn.IsAuthenticated=true;
                UserReturn.Token =new JwtSecurityTokenHandler().WriteToken(jwtToken);
                UserReturn.PhoneNumber = user.PhoneNumber;
                var roles=await _userManager.GetRolesAsync(user);
                UserReturn.Roles = roles.ToList();
                UserReturn.RefreshToken=refreshToken.Token;
                UserReturn.RefreshTokenExpiration=refreshToken.ExpiresOn;
            }
            return UserReturn;
        }

        public async Task<AuthRegisterDto> RegisterAsync(RegisterDto model)
        {

            if (await Find(X => X.PhoneNumber == model.PhoneNumber) is not null)
            {
                return new AuthRegisterDto { Message = "Phone is already registered!" };
            }
            
            var user = model.Adapt<User>();
            var result = await _userManager.CreateAsync(user);

           
            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthRegisterDto { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "User");

            var jwtSecurityToken = await CreateJwtToken(user);
            var refreshToken = GenerateRefreshToken();
            user.RefreshTokens?.Add(refreshToken);
            await _userManager.UpdateAsync(user);
            return new AuthRegisterDto
            {
                PhoneNumber = user.PhoneNumber,
                //ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiration= refreshToken.ExpiresOn,
                UserId = user.Id,
                RegWay=model.RegWay
                
                
            };
        }

        //addroleToUSER

        public async Task<string> AddRoleAsync(AddRoleModelDto model)
        {
            var user = await Find(x => x.PhoneNumber == model.PhoneNumber);
            var user2= await _userManager.FindByIdAsync(user.Id);
           
            var role = await _roleManager.RoleExistsAsync(model.RoleName);
               if (user2 is null || !role)
                   return "Invalid user ID or Role";
            var check = await _userManager.IsInRoleAsync(user2, model.RoleName);
                if (check)
                  return "User already assigned to this role";

              var result = await _userManager.AddToRoleAsync(user2, model.RoleName);

                return result.Succeeded ? string.Empty : "Something went wrong";
            //}
        }
        private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.PhoneNumber.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserName", user.UserName),
               
                new Claim("uid", user.Id)
            };


            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var generator = new RNGCryptoServiceProvider();

            generator.GetBytes(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(30),
                CreatedOn = DateTime.UtcNow
            };
        }

        public async Task<AuthRegisterDto> RefreshTokenAsync(string token)
        {
            var authModel = new AuthRegisterDto();

            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
            {
                authModel.Message = "Invalid token";
                return authModel;
            }

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
            {
                authModel.Message = "Inactive token";
                return authModel;
            }

            refreshToken.RevokedOn = DateTime.UtcNow;

            var newRefreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
       

            var jwtToken = await CreateJwtToken(user);
            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            authModel.PhoneNumber = user.PhoneNumber;
            
            var roles = await _userManager.GetRolesAsync(user);
            authModel.Roles = roles.ToList();
            authModel.RefreshToken = newRefreshToken.Token;
            authModel.RefreshTokenExpiration = newRefreshToken.ExpiresOn;

            return authModel;

        }

        public async Task<bool> RevokeTokenAsync(string token)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
                return false;

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
                return false;

            refreshToken.RevokedOn = DateTime.UtcNow;

            await _userManager.UpdateAsync(user);

            return true;
        }

        

    }
}
