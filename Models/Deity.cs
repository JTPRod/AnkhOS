namespace KemeticReference.Models;
public sealed class Deity
{
 public string Id { get; set; } = "";
 public string Name { get; set; } = "";
 public List<string> AlternateNames { get; set; } = [];
 public string Summary { get; set; } = "";
 public bool IsPlaceholder { get; set; } = true;
 public List<ContentEntry> Background { get; set; } = [];
 public List<ContentEntry> Associations { get; set; } = [];
 public List<ContentEntry> WorshipPractices { get; set; } = [];
 public List<ContentEntry> DevotionalActs { get; set; } = [];
 public List<SourceReference> Sources { get; set; } = [];
 public DateOnly? LastReviewed { get; set; }
 public string EgyptianName { get; set; } = "";
 public List<string> Crystals { get; set; } = [];
 public List<ContentEntry> DivinationMethods { get; set; } = [];
 public List<ContentEntry> Offerings { get; set; } = [];
}
