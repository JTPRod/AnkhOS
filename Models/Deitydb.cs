namespace KemeticReference.Models;

public class Deitydb
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;

    public ICollection<UserFavorite> Favorites { get; set; } = new List<UserFavorite>();
}