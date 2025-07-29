namespace GlowMate2.Shared.Services;

public interface IAuthService
{
    Task<string> GetCurrentUserIdAsync();
    Task<string?> GetAccessTokenAsync();
    Task<bool> IsAuthenticatedAsync();
    Task<bool> RefreshTokenAsync();
    Task<bool> LoginAsync();
    Task LogoutAsync();
}
