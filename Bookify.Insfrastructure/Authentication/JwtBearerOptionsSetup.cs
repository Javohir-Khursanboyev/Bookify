using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace Bookify.Insfrastructure.Authentication;

internal sealed class JwtBearerOptionsSetup(IOptions<AuthenticationOptions> authenticationOptions)
    : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly AuthenticationOptions authenticationOptions = authenticationOptions.Value;

    public void Configure(string? name, JwtBearerOptions options)
    {
        Configure(options);
    }

    public void Configure(JwtBearerOptions options)
    {
        options.Audience = authenticationOptions.Audience;
        options.MetadataAddress = authenticationOptions.MetadataUrl;
        options.RequireHttpsMetadata = authenticationOptions.RequireHttpsMetadata;
        options.TokenValidationParameters.ValidIssuer = authenticationOptions.ValidIssuer;
    }
}