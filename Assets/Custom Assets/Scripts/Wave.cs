using UnityEngine;
using System.Collections.Generic;

public class Wave : MonoBehaviour, IEnumerator<Object>
{

    public Object[] SpawnOrder;
    public float SpawnRate;

    public int Repeat = 1;

    private int repeat;
    private int index;

    public Wave()
    {
        Reset();
    }

    public Object Current
    {
        get { return SpawnOrder[index]; }
    }

    public void Dispose()
    {
        index = 0;
    }

    object System.Collections.IEnumerator.Current
    {
        get { return Current; }
    }

    public bool MoveNext()
    {
        index++;

        bool next = index < SpawnOrder.Length;

        if (!next && ++repeat < Repeat)
        {
            index = 0;
            next = true;
        }

        return next;
    }

    public void Reset()
    {
        index = -1;
        repeat = 0;
    }
}

