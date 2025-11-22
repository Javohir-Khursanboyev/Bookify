using Bookify.Domain.Users;

namespace Bookify.Insfrastructure.Authentication.Models;

public sealed class UserRepresentationalModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public bool Enabled { get; set; } 
    public bool EmailVerified { get; set; }
    public CredentialRepresentationalModel[] Credentials { get; set; }
    internal static UserRepresentationalModel FromUser(User user)
    {
        return new()
        {
            FirstName = user.FirstName.Value,
            LastName = user.LastName.Value,
            Email = user.Email.Value,
            Username = user.Email.Value,
            Enabled = true,
            EmailVerified = true
        };
    }
}