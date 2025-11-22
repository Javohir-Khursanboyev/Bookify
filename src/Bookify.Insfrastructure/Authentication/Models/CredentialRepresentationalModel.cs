namespace Bookify.Insfrastructure.Authentication.Models;

public sealed class CredentialRepresentationalModel
{
    public string Type { get; set; }

    public string Value { get; set; }
    public bool Temporary { get; set; }
}