namespace TrademarksRegistrar;

public class Registrar
{
    public int Count => _registered.Count;
    private readonly HashSet<string> _registered = new();

    public bool TryRegister(string trademark)
    {
        var normalized = NormalizeTrademark(trademark);
        return _registered.Add(normalized);
    }

    private string NormalizeTrademark(string trademark)
    {
        // Оставляем только те символы, для которых предшествующие 2 символы не совпадают с проверяемым
        var chars = trademark.Where((chr, i) =>
        {
            if (i < 2) return true;
            var prevTwoCharsEqualToCurrent = chr == trademark[i - 1] && chr == trademark[i - 2];
            return !prevTwoCharsEqualToCurrent;
        });
        return new string(chars.ToArray());
    }
}