using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour {
	
	void Update () {
		transform.LookAt(new Vector3(transform.position.x, 1000, transform.position.z));
		transform.Rotate(0, 0, 270);
	}
}