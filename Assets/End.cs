using UnityEngine;
using System.Collections;

public class End : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log("Collision");
		Destroy(other.gameObject);
	}
}