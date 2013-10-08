using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{	
    public Wave wave;

	void Start()
    {
        wave.start = gameObject.transform.position;
        wave.SpawnAll(1f);
	}
}