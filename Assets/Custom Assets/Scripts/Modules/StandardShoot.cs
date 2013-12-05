using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ModuleProperties))]
public class StandardShoot : MonoBehaviour {

	protected ModuleProperties Module;

	public GameObject Ammo;

	public AudioClip SoundEffect;

	public float BulletSpeed;

	// Use this for initialization
	void Start() {
		Module = gameObject.GetComponent<ModuleProperties>();

		Invoke("Shoot", 0);
	}
	
	// Update is called once per frame
	void Update() {

	}

	protected virtual void Shoot() {
		if (Module.CurrentTarget == null) {
			Invoke("Shoot", .1f);
			return;
		}

		GameObject projectile = (GameObject)Instantiate(Ammo, transform.position, transform.rotation);
		AudioSource.PlayClipAtPoint(SoundEffect, Camera.main.transform.position, .5f);
		projectile.rigidbody.AddForce(transform.forward * BulletSpeed * 1000f);

		Projectile proj = projectile.GetComponent<Projectile>();
		proj.Module = gameObject.GetComponent<ModuleProperties>();
		proj.Damage = CalculateDamage();

		Invoke("Shoot", CalculateAttackSpeed());
	}

	protected float CalculateAttackSpeed() {
		float attackSpeed = Module.AttackSpeed;
		
		AttackModifier am = transform.parent.gameObject.GetComponent<AttackModifier>();
		
		if(am != null)
		{
			attackSpeed = am.ModifyAttackSpeed(attackSpeed);
		}

		return attackSpeed;
	}

	protected float CalculateDamage() {
		
		float damage = Module.Damage;
		
		AttackModifier am = Module.Base.gameObject.GetComponent<AttackModifier>();
		
		if(am != null)
		{
			damage = am.ModifyDamage(damage);
		}
		
		return damage;
	}
}