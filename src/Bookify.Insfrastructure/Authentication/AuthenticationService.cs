using System.Net.Http.Json;
using Bookify.Application.Abstractions.Authentication;
using Bookify.Domain.Users;
using Bookify.Insfrastructure.Authentication.Models;

namespace Bookify.Insfrastructure.Authentication;

internal sealed class AuthenticationService(HttpClient httpClient) : IAuthenticationService
{
    private const string PasswordCredentialType = "password";
    public async Task<string> RegisterUserAsync(User user, string password, CancellationToken cancellationToken)
    {
        var userRepresentationalModel = UserRepresentationalModel.FromUser(user);

        userRepresentationalModel.Credentials =
        [
            new()
            {
                Type = PasswordCredentialType,
                Value = password,
                Temporary = false
            }
        ];

        var response = await httpClient.PostAsJsonAsync(
          "users",
          userRepresentationalModel,
          cancellationToken);

        return ExtractIdentityIdFromLocationHeader(response);
    }

    private string ExtractIdentityIdFromLocationHeader(HttpResponseMessage httpResponseMessage)
    {
        const string usersSegmentName = "users/";

        var locationHeader = httpResponseMessage.Headers.Location?.PathAndQuery;

        if (locationHeader is null)
            throw new InvalidOperationException("Location header cannot be null");

        var userSegmentValueIndex = locationHeader.IndexOf(
            usersSegmentName,
            StringComparison.InvariantCultureIgnoreCase);

        var userIdentityId = locationHeader.Substring(
            userSegmentValueIndex + usersSegmentName.Length);

        return userIdentityId;
    }
}