using UnityEngine;
using System.Collections;

public class RockyShoot : StandardShoot {

	private GameObject CurrentTarget;

	public int CurrentStacks = 0;

	public float AttackSpeedIncreasePerStack = 0.05f;

	public float DamageIncreasePerStack = 5;

	public int MaxStacks = 6;

	protected override void Shoot() {

		if (Module.CurrentTarget == null) {
			Invoke("Shoot", .1f);
			return;
		}

		if (CurrentTarget != Module.CurrentTarget) {
			CurrentTarget = Module.CurrentTarget;
			CurrentStacks = 0;
		}

		GameObject projectile = (GameObject)Instantiate(Ammo, transform.position, transform.rotation);
		AudioSource.PlayClipAtPoint(SoundEffect, Camera.main.transform.position, .5f);
		projectile.rigidbody.AddForce(transform.forward * BulletSpeed * 1000f);
		
		Projectile proj = projectile.GetComponent<Projectile>();
		proj.Module = gameObject.GetComponent<ModuleProperties>();
		proj.Damage = CalculateDamage() + DamageIncreasePerStack * CurrentStacks;

		CurrentStacks = Mathf.Min(CurrentStacks + 1, MaxStacks);

		Invoke("Shoot", CalculateAttackSpeed() - AttackSpeedIncreasePerStack * CurrentStacks);
	}
}
