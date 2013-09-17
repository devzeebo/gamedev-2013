using UnityEngine;
using System.Collections;

public class KillOnFinish : MonoBehaviour {

	void Update () {
		if (particleSystem.time > 0.5f)
			Destroy(gameObject);
	}
}