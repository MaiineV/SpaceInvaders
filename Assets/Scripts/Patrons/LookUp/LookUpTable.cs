using System;
using System.Collections.Generic;

public class LookUpTable<T1, T2>
{
    private readonly Func<T1, T2> _factoryMethod;
    private readonly Dictionary<T1, T2> _table;

    public LookUpTable(Func<T1, T2> factoryMethod)
    {
        _factoryMethod = factoryMethod;
        _table = new Dictionary<T1, T2>();
    }

    public T2 GetResult(T1 input)
    {
        if (_table.TryGetValue(input, out var result1)) return result1;

        var result = _factoryMethod(input);
        _table.Add(input, result);
        return result;
    }
}
