using System;
using System.Collections.Generic;

public class ObjectPool<T>
{
    private readonly Factory<T> _factory;

    private readonly Queue<T> _poolQueue = new Queue<T>();

    private readonly Action<T> _returnMethod;
    private readonly Action<T> _getMethod;

    public ObjectPool(Factory<T> factory, int initialAmount, Action<T> returnMethod, Action<T> getMethod)
    {
        _factory = factory;

        _returnMethod = returnMethod;
        _getMethod = getMethod;

        for (var i = 0; i < initialAmount; i++)
        {
            ReturnObject(_factory.CreateObject());
        }
    }

    public T GetObject()
    {
        var obj = _poolQueue.Count > 0 ? _poolQueue.Dequeue() : _factory.CreateObject();

        _getMethod(obj);
        
        return obj;
    }

    public void ReturnObject(T obj)
    {
        _returnMethod(obj);
        _poolQueue.Enqueue(obj);
    }
}