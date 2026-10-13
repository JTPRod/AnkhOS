using System.ComponentModel.DataAnnotations;
namespace KemeticReference.Models;
public sealed class PostReport
{
 public long Id { get; set; }
 public long PostId { get; set; }
 [Required] public string ReporterUserId { get; set; } = "";
 [Required, StringLength(1000)] public string Reason { get; set; } = "";
 public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
 public ReportStatus Status { get; set; } = ReportStatus.Open;
 public string? ResolutionNote { get; set; }
}
