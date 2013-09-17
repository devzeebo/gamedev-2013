using UnityEngine;
using System.Collections;

public class End : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (GetComponent<Health>().CurrentHealth > 0)
			GetComponent<Health>().CurrentHealth--;
		Destroy(other.gameObject);
	}
}