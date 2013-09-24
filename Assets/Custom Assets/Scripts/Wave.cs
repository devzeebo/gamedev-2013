using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

    public Object[] SpawnOrder;
    public float SpawnRate;

    private int repeat;
    public int Repeat = 1;

    internal Vector3 start;

    private int index;

    public void Spawn()
    {
        Debug.LogWarning(index + " " + SpawnOrder.Length);
        if (index == SpawnOrder.Length)
        {
            if (--repeat <= 0)
            {
                CancelInvoke();
                return;
            }
            index = 0;
        }

        if (SpawnOrder[index] is Wave)
        {
            ((Wave)SpawnOrder[index]).SpawnAll(0);
        }
        else
        {
            GameObject createdEnemy = (GameObject)Instantiate(SpawnOrder[index], start, Quaternion.identity);
        }

        index++;
    }

    public void SpawnAll(float delay)
    {
        index = 0;
        repeat = Repeat;
        Debug.LogWarning("Spawning: " + delay + " " + SpawnRate);
        InvokeRepeating("Spawn", delay, SpawnRate);
    }
}
