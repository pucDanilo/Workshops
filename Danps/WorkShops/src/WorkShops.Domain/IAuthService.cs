namespace WorkShops.Domain.Services
{
    public interface IAuthService
    {
        bool IsValid(string username, string password);

        TokenResponse GetTokenResponse(string username, string password);
    }
}