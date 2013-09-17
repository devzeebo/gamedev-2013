using UnityEngine;
using System.Collections;

public class LookAtEnemy : MonoBehaviour {

	GameObject tracking;
	bool attacking;
	
	public GameObject ammo;
	
	void Start () {
		tracking = null;
		attacking = false;
	}
	
	void Update () {
		if (tracking != null)
		{
			transform.parent.LookAt(tracking.transform.position + tracking.transform.forward * 3.5f);
			
			if (!attacking)
			{
				attacking = true;
				Invoke("Shoot", .25f);
			}
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Trigger Enter");
		if (other.tag == "Enemy")
		{
			if (tracking == null)
				tracking = other.gameObject;
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Enemy")
		{
			if (tracking == null)
				tracking = other.gameObject;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == tracking)
			tracking = null;
	}
	
	void Shoot()
	{
		GameObject projectile = (GameObject)Instantiate(ammo, transform.position, transform.rotation);
		
		projectile.GetComponent<KillOnCollide>().tower = this;
		projectile.rigidbody.AddForce(transform.parent.forward * 1000f);
		
		attacking = false;
	}
	
	public void RemoveTracking()
	{
		tracking = null;
		CancelInvoke();
		attacking = false;
	}
}