using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WorkShops.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtSettings jwt;

        /*
// Usuários de exemplo (NÃO use plaintext em produção)
private static readonly Dictionary<string, (string Password, string[] Roles)> Users = new()
{
};
*/
        private readonly IEnumerable<UserVO> Users;

        public AuthService(IOptions<JwtSettings> mySettingsOptions)
        {
            jwt = mySettingsOptions.Value;
            Users = new List<UserVO> {
                new UserVO("string", "string", new[] { "Admin", "Instructor" }),
                new UserVO("admin@campus", "admin123", new[] { "Admin", "Instructor" }),
                new UserVO("inst@campus", "inst123", new[] { "Instructor" }),
                new UserVO("aluno@campus", "aluno123", Array.Empty<string>())
            };
        }

        public bool IsValid(string username, string password)
        {
            var u = Users.First(a => a.Name == username && a.Password == password);
            return u != null;
        }

        public TokenResponse GetTokenResponse(string username, string password)
        {
            var u = Users.First(a => a.Name == username && a.Password == password);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, username),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            claims.AddRange(u.Roles.Select(r => new Claim(ClaimTypes.Role, r.Name)));

            var expires = DateTime.UtcNow.AddHours(jwt.ExpiresAt);

            var token = new JwtSecurityToken(
                issuer: jwt.Issuer,
                audience: jwt.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            var encoded = new JwtSecurityTokenHandler().WriteToken(token);
            return new TokenResponse(encoded, expires);
        }
    }
}