using System.ComponentModel.DataAnnotations;
namespace KemeticReference.Models;
public sealed class CommunityPost
{
 public long Id { get; set; }
 [Required] public string AuthorUserId { get; set; } = "";
 [Required] public string DeityId { get; set; } = "";
 public PostKind Kind { get; set; }
 [Required, StringLength(120)] public string Title { get; set; } = "";
 [Required, StringLength(5000)] public string Body { get; set; } = "";
 public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
 public DateTime? UpdatedAtUtc { get; set; }
 public PostStatus Status { get; set; } = PostStatus.Visible;
 public string? ModeratorReason { get; set; }
}
