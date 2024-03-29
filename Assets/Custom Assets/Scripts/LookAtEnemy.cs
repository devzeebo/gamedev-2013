﻿using UnityEngine;
using System.Collections;

public class LookAtEnemy : MonoBehaviour {
	
	public GameObject range;
	internal GameObject tracking;
	bool attacking;
	public float AimModifier;
	public float AttackSpeed;

    public AudioClip SquirrelThrow;

    public float BulletSpeed = 1f;
	
	public GameObject ammo;
	
	void Start () {
		tracking = null;
		attacking = false;
	}
	
	void Update () {
		
		if (tracking != null)
		{
			Debug.Log (tracking.transform.position);
			transform.LookAt(tracking.transform.position + tracking.transform.forward * AimModifier);
			
			if (!attacking)
			{
				float attackSpeed = AttackSpeed;
				
				AttackModifier am = transform.parent.gameObject.GetComponent<AttackModifier>();
				
				if(am != null)
				{
					attackSpeed = am.ModifyAttackSpeed(attackSpeed);
				}
				attacking = true;
				Invoke("Shoot", attackSpeed);
			}
		}
	}
	
	void Shoot()
	{
		GameObject projectile = (GameObject)Instantiate(ammo, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(SquirrelThrow, Camera.main.transform.position, .5f);
		projectile.GetComponent<KillOnCollide>().tower = this;
		projectile.rigidbody.AddForce(transform.forward * BulletSpeed * 1000f);
		
		attacking = false;
	}
	
	public void RemoveTracking()
	{
		tracking = null;
		CancelInvoke();
		attacking = false;
	}
}