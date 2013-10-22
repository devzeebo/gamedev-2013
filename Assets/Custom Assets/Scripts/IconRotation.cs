using UnityEngine;
using System.Collections;

public class IconRotation : MonoBehaviour {

    public float speed;

	void Start () {
	
	}
	
	void Update () {
        transform.Rotate(0, Time.deltaTime * speed, 0);
	}
}