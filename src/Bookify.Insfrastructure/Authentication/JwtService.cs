using System.Net.Http.Json;
using Bookify.Domain.Abstractions;
using Microsoft.Extensions.Options;
using Bookify.Insfrastructure.Authentication.Models;
using Bookify.Application.Abstractions.Authentication;

namespace Bookify.Insfrastructure.Authentication;

internal sealed class JwtService : IJwtService
{
    private static readonly Error AuthenticationFailed = new(
        "Keykloak.AuthenticationFailed",
        "Failed to asquire acces token do to authentication failure");

    private readonly HttpClient httpClient;
    private readonly KeycloakOptions keycloakOptions;
    public JwtService(HttpClient httpClient, IOptions<KeycloakOptions> keycloakOptions)
    {
        this.httpClient = httpClient;
        this.keycloakOptions = keycloakOptions.Value;
    }
    public async Task<Result<string>> GetAccesTokenAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        try
        {
            var authRequestParametrs = new KeyValuePair<string, string>[]
            {
                new("client_id", keycloakOptions.AuthClientId),
                new("client_secret", keycloakOptions.AuthClientSecret),
                new("scope", "openid"),
                new("grant_type", "password"),
                new("username", email),
                new("password", password),
            };

            var authorizationRequestContent = new FormUrlEncodedContent(authRequestParametrs);

            var response = await httpClient.PostAsync("", authorizationRequestContent, cancellationToken);
            response.EnsureSuccessStatusCode();

            var authorizationToken = await response.Content.ReadFromJsonAsync<AuthorizationToken>();
            if (authorizationToken is null)
            {
                return Result.Failure<string>(AuthenticationFailed);
            }

            return authorizationToken.AccessToken;
        }
        catch (HttpRequestException)
        {
            return Result.Failure<string>(AuthenticationFailed);
        }
    }
}
