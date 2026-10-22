namespace KemeticReference.Services;

public sealed class DeitySearchState
{
    public string Query { get; private set; } = "";

    public event Action? Changed;

    public void SetQuery(string? value)
    {
        var nextValue = value ?? "";

        if (Query == nextValue)
        {
            return;
        }

        Query = nextValue;
        Changed?.Invoke();
    }
}