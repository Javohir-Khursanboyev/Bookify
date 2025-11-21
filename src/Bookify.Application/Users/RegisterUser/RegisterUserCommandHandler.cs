using Bookify.Application.Abstractions.Authentication;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Users;

namespace Bookify.Application.Users.RegisterUser;

public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository userRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IAuthenticationService authenticationService;

    public RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IAuthenticationService authenticationService)
    {
        this.userRepository = userRepository;
        this.unitOfWork = unitOfWork;
        this.authenticationService = authenticationService;
    }
    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(
            new FirstName(request.FirstName),
            new LastName(request.LastName),
            new Email(request.Email)
            );

        var identityId = await authenticationService.RegisterUserAsync(user, request.Password, cancellationToken);
        user.SetIdentityId(identityId);

        userRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}