using UnityEngine;
using System.Collections;

public class RocketShoot : StandardShoot {
	

	// Update is called once per frame
	void Update () {
	
	}

	protected override void Shoot() {
		if (Module.CurrentTarget == null) {
			Invoke("Shoot", .1f);
			return;
		}

		GameObject projectile = (GameObject)Instantiate(Ammo, transform.position, transform.rotation);
		AudioSource.PlayClipAtPoint(SoundEffect, Camera.main.transform.position, .5f);
		projectile.rigidbody.AddForce(transform.forward * BulletSpeed * 1000f);
		
		Projectile proj = projectile.GetComponent<Projectile>();
		proj.Module = gameObject.GetComponent<ModuleProperties>();
		
		Invoke("Shoot", CalculateAttackSpeed());
	}
}

