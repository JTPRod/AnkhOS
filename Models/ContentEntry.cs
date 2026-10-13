namespace KemeticReference.Models;
public sealed class ContentEntry
{
 public string Text { get; set; } = "";
 public string EvidenceType { get; set; } = "";
 public string Context { get; set; } = "";
 public List<string> SourceIds { get; set; } = [];
}
