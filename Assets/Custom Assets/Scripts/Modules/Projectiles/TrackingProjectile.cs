using UnityEngine;
using System.Collections;

public class TrackingProjectile : Projectile {

	public GameObject Target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(Target.transform);
		transform.Translate(Vector3.forward);
	}
}
 