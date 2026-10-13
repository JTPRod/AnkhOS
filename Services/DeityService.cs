using System.Text.Json;
using KemeticReference.Models;
namespace KemeticReference.Services;
public sealed class DeityService(IWebHostEnvironment environment)
{
 private readonly SemaphoreSlim gate = new(1, 1);
 private IReadOnlyList<Deity>? cache;
 public async Task<IReadOnlyList<Deity>> GetAllAsync()
 {
  await gate.WaitAsync();
  try
  {
   if (cache is not null) return cache;
   var path = Path.Combine(environment.ContentRootPath, "Data", "Reference", "deities.json");
   await using var stream = File.OpenRead(path);
   var records = await JsonSerializer.DeserializeAsync<List<Deity>>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
    ?? throw new InvalidDataException("Reference catalog is empty.");
   var ids = new HashSet<string>(StringComparer.Ordinal);
   foreach (var deity in records)
   {
    if (string.IsNullOrWhiteSpace(deity.Id) || deity.Id.Any(c => !(c >= 'a' && c <= 'z') && !(c >= '0' && c <= '9') && c != '-') || !ids.Add(deity.Id) || string.IsNullOrWhiteSpace(deity.Name))
     throw new InvalidDataException("Invalid or duplicate deity ID/name.");
    var sources = deity.Sources.Select(s => s.Id).ToHashSet();
    if (sources.Count != deity.Sources.Count) throw new InvalidDataException("Duplicate source IDs.");
    foreach (var source in deity.Sources)
     if (source.Url is not null && (!Uri.TryCreate(source.Url, UriKind.Absolute, out var uri) || (uri.Scheme != "https" && uri.Scheme != "http")))
      throw new InvalidDataException("Invalid source URL.");
    foreach (var entry in deity.Background.Concat(deity.Associations).Concat(deity.WorshipPractices).Concat(deity.DevotionalActs))
     if (string.IsNullOrWhiteSpace(entry.Text) || entry.SourceIds.Count == 0 || entry.SourceIds.Any(id => !sources.Contains(id)))
      throw new InvalidDataException("Content needs text and valid source references.");
   }
   cache = records.AsReadOnly();
   return cache;
  }
  finally { gate.Release(); }
 }
 public async Task<Deity?> GetByIdAsync(string id) => (await GetAllAsync()).FirstOrDefault(d => d.Id == id);
}
