namespace KemeticReference.Models;
public class UserFavorite
{
    public string UserId { get; set; } = string.Empty;
    public int DeityId { get; set; }

    public Deitydb Deity { get; set; } = null!;
}