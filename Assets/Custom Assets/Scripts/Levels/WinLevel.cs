using UnityEngine;
using System.Collections;

public class WinLevel : MonoBehaviour {

	private WaveManager Manager;

	// Use this for initialization
	void Start () {
		Manager = gameObject.GetComponent<WaveManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Manager.IsDone() && GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
			Debug.Log("WIN!");
		}
	}
}
