using UnityEngine;
using System.Collections;

public class Icon : MonoBehaviour {

    public GameObject SpawnObject;
    public int queue;

    void Start()
    {
        renderer.sharedMaterial.renderQueue = queue;
    }
}