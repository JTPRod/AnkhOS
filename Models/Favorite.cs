using System.ComponentModel.DataAnnotations;
namespace KemeticReference.Models;
public sealed class Favorite
{
 public long Id { get; set; }
 [Required] public string UserId { get; set; } = "";
 [Required] public string DeityId { get; set; } = "";
 public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
}
