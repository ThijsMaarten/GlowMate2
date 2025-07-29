using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using GlowMate2.Shared.Services;
using System.Security.Claims;

namespace GlowMate2.Web.Client.Services;

public class WebAuthService : IAuthService
{
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly IAccessTokenProvider _tokenProvider;
    private readonly NavigationManager _navigation;

    public WebAuthService(
        AuthenticationStateProvider authStateProvider,
        IAccessTokenProvider tokenProvider,
        NavigationManager navigation)
    {
        _authStateProvider = authStateProvider;
        _tokenProvider = tokenProvider;
        _navigation = navigation;
    }

    public async Task<string> GetCurrentUserIdAsync()
    {
        var authState = await _authStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        return user.Identity?.IsAuthenticated == true
            ? user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty
            : string.Empty;
    }

    public async Task<string?> GetAccessTokenAsync()
    {
        var result = await _tokenProvider.RequestAccessToken();
        if (result.TryGetToken(out var token))
        {
            return token.Value;
        }
        return null;
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        var authState = await _authStateProvider.GetAuthenticationStateAsync();
        return authState.User.Identity?.IsAuthenticated == true;
    }

    public async Task<bool> RefreshTokenAsync()
    {
        // In Blazor WASM, tokens are refreshed automatically when possible.
        // You can force a new token request by omitting ForceRefresh and relying on scopes.
        var result = await _tokenProvider.RequestAccessToken();
        return result.TryGetToken(out _);
    }

    public async Task<bool> LoginAsync()
    {
        // In Blazor WASM, login is typically handled via redirect.
        // You can trigger it by navigating to the authentication endpoint.
        _navigation.NavigateTo("authentication/login");
        await Task.CompletedTask;
        return false; // Will redirect, so this is not reached.
    }

    public async Task LogoutAsync()
    {
        _navigation.NavigateTo("authentication/logout");
        await Task.CompletedTask;
    }
}
