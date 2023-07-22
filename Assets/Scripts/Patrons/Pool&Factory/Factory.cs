using System;

public class Factory<T>
{
    private readonly Func<T> _factoryMethod;

    public Factory(Func<T> factoryMethod)
    {
        _factoryMethod = factoryMethod;
    }

    public T CreateObject()
    {
        return _factoryMethod();
    }
}
