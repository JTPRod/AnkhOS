using Microsoft.AspNetCore.Identity;

namespace KemeticReference.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    private int _userId;
    private string? _email;
    private string? _password;

    public int UserId
    {
        get => _userId;
        set => _userId = value;
    }

    public string? Email
    {
        get => _email;
        set => _email = value;
    }

    public bool CorrectPassword(string password)
    {
        return _password == password;
    }
}

