using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{	
    public List<Wave> waves;

    public int CurrentWave = 0;

    public float WaveWarmupTime = 3;

    private Stack<Wave> waveStack;

	private long nextInvokeInterval;
	
	private bool paused;
	
	public AudioClip WaveStart;

    public WaveManager()
    {
        waveStack = new Stack<Wave>();
    }

	public void Start()
    {
        if (waveStack.Count == 0 && CurrentWave < waves.Count)
        {
			AudioSource.PlayClipAtPoint(WaveStart, Camera.main.transform.position);
            waveStack.Push(waves[CurrentWave++]);
            waveStack.Peek().Reset();
        }

        if (paused)
        {
            paused = false;
            Invoke("Spawn", nextInvokeInterval / 1000f);
        }
        else
        {
            if (!IsInvoking("Spawn"))
            {
                Invoke("Spawn", WaveWarmupTime);
            }
        }
	}

    public void Pause()
	{
		paused = true;
        nextInvokeInterval = nextInvokeInterval - Utilities.GetCurrentTimeMillis();
	}

    public void Stop()
    {
        paused = false;
        waveStack.Clear();
        nextInvokeInterval = 0;
    }

    void Spawn()
    {
        Debug.Log("Spawn");
        if (waveStack.Count > 0)
        {
            Wave current = waveStack.Peek();

            if (current.MoveNext())
            {
                Debug.Log("Next");
                if (current.Current is Wave)
                {
                    Debug.Log("Spawned wave");
                    waveStack.Push(current.Current as Wave);
                    Spawn();
                    return;
                }
                else
                {
                    Debug.Log("Spawned enemy");
                    GameObject createdEnemy = (GameObject)Instantiate(current.Current, gameObject.transform.position, Quaternion.identity);
                    nextInvokeInterval = Utilities.GetCurrentTimeMillis() + (long)(waveStack.Peek().SpawnRate * 1000);
                }
            }
            else
            {
                Debug.Log("No Next :(");
                waveStack.Peek().Reset();
                waveStack.Pop();
            }

            if (waveStack.Count == 0)
            {
                CurrentWave++;
                Stop();
            }
            else
            {
                Invoke("Spawn", current.SpawnRate);
            }
        }
    }
}