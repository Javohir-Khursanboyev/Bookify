using System.Windows.Input;
using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Users.LoginUser;

public sealed record LoginUserCommand(string Email, string Paswword) : ICommand<AccesTokenResponse>;