using GlowMate2.Shared.Services;
using Microsoft.Identity.Client;

namespace GlowMate2.Services;

public class AppAuthService : IAuthService
{
    private readonly IPublicClientApplication _pca;
    private AuthenticationResult? _authResult;
    private IAccount? _account;

#if DEBUG
    private const string RedirectUri = "http://localhost";
#else
        private const string RedirectUri = "msalb743f99e-aff2-4d44-9a9f-77ba719d24c5://auth";
#endif

    private const string ClientId = "b743f99e-aff2-4d44-9a9f-77ba719d24c5";
    private const string TenantId = "dfca0cfe-df91-4d7d-af94-2d777aeb439c";
    private readonly string[] Scopes = new[] { "User.Read" };

    public AppAuthService()
    {
        _pca = PublicClientApplicationBuilder
            .Create(ClientId)
            .WithTenantId(TenantId)
            .WithRedirectUri(RedirectUri)
            .Build();
    }

    public Task<string> GetCurrentUserIdAsync()
    {
        return Task.FromResult(
            _account?.Username ?? string.Empty
        );
    }

    public async Task<string?> GetAccessTokenAsync()
    {
        if (_authResult != null && !string.IsNullOrEmpty(_authResult.AccessToken))
            return _authResult.AccessToken;

        // Try silent token acquisition
        if (_account != null)
        {
            try
            {
                _authResult = await _pca.AcquireTokenSilent(Scopes, _account).ExecuteAsync();
                return _authResult.AccessToken;
            }
            catch (MsalUiRequiredException)
            {
                // Silent failed, need interactive
                return null;
            }
        }
        return null;
    }

    public Task<bool> IsAuthenticatedAsync()
    {
        return Task.FromResult(
            _authResult != null && !string.IsNullOrEmpty(_authResult.AccessToken)
        );
    }

    public async Task<bool> RefreshTokenAsync()
    {
        if (_account == null)
            return false;

        try
        {
            _authResult = await _pca.AcquireTokenSilent(Scopes, _account).ExecuteAsync();
            return true;
        }
        catch (MsalUiRequiredException)
        {
            // Silent refresh failed, need interactive login
            return false;
        }
    }

    public async Task LogoutAsync()
    {
        if (_account != null)
        {
            await _pca.RemoveAsync(_account);
            _account = null;
            _authResult = null;
        }
    }

    public async Task<bool> LoginAsync()
    {
        try
        {
            _authResult = await _pca.AcquireTokenInteractive(Scopes).ExecuteAsync();
            _account = _authResult.Account;
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Login failed: {ex}");
            return false;
        }
    }
}
