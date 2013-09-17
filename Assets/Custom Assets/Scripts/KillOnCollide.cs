using UnityEngine;
using System.Collections;

public class KillOnCollide : MonoBehaviour {
	
	public LookAtEnemy tower;

	void Start () {
	}
	
	void Update () {
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			Destroy(other.gameObject);
			tower.RemoveTracking();
			Destroy(gameObject);
		}
		else if (other.tag == "Terrain")
			Destroy(gameObject);
	}
}