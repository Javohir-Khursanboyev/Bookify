using Bookify.Application.Abstractions.Authentication;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Users;

namespace Bookify.Application.Users.LoginUser;

internal sealed class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, AccesTokenResponse>
{
    private readonly IJwtService jwtService;
    public LoginUserCommandHandler(IJwtService jwtService)
    {
        this.jwtService = jwtService;
    }
    public async Task<Result<AccesTokenResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var result = await jwtService.GetAccesTokenAsync(request.Email, request.Paswword, cancellationToken);

        if(result.IsFailure)
        {
            return Result.Failure<AccesTokenResponse>(UserErrors.InvalidCredentials);
        }

        return new AccesTokenResponse(result.Value);
    }
}