namespace WorkShops.Domain.Services
{
    public record LoginRequest(string Username, string Password);
    public record TokenResponse(string AccessToken, DateTime ExpiresAt);

    public class UserVO
    {
        public UserVO(string Name, string Password, string[] Roles)
        {
            this.Password = Password;
            this.Name = Name;
            this.Roles = Roles.Select(a => new RoleVO(a));
        }

        public string Password { get; set; }
        public string Name { get; set; }
        public IEnumerable<RoleVO> Roles { get; set; }
    }

    public class RoleVO
    {
        public RoleVO(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}