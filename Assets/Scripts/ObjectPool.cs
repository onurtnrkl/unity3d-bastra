#region License
// ====================================================
// Product:    Bastra
// Developer:  Onur Tanrıkulu
// Date:       31/03/2019 00:50
// Copyright (c) 2019 Onur Tanrikulu. All rights reserved.
// ====================================================
#endregion

using System.Collections.Generic;

public class ObjectPool<T>
{
    private Queue<T> gameObjects;

    /// <summary>
    /// Creates pool for game objects.
    /// </summary>
    /// <param name="size">Pool size</param>
    public ObjectPool(int size)
    {
        gameObjects = new Queue<T>(size);
    }

    public T GetObject()
    {
        return gameObjects.Dequeue();
    }

    public void AddObject(T gameObject)
    {
        gameObjects.Enqueue(gameObject);
    }
}