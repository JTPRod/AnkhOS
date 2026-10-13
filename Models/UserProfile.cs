using System.ComponentModel.DataAnnotations;
namespace KemeticReference.Models;
public sealed class UserProfile
{
 [Key] public string UserId { get; set; } = "";
 [Required, StringLength(50, MinimumLength=1)] public string DisplayName { get; set; } = "";
 [StringLength(500)] public string Bio { get; set; } = "";
 public string AvatarKey { get; set; } = "default";
 public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;
}
