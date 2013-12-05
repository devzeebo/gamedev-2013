﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public GameObject MissEffect;

	public GameObject HitEffect;

	public AudioClip EnemyHit;

	private ModuleProperties module;
	public ModuleProperties Module {
		get { return module; }
		set {
			module = value;
			Base = module.Base;
		}
	}

	public BaseProperties Base;

	private Experience xp;

	// Use this for initialization
	void Start() {
		xp = GameObject.Find("Global").GetComponent<Experience>();
	}
	
	// Update is called once per frame
	void Update() {
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			HitEnemy(other.gameObject);
		}
		if (other.tag == "Terrain") {
			HitTerrain(other.gameObject);
		}
	}

	void HitEnemy(GameObject other) {

		Health objHealth = other.gameObject.GetComponent<Health>();

		float damage = CalculateDamage();

		xp.GiveExperienceHit(Base.gameObject.GetComponent<Description>().name, damage, objHealth.maxHealth, 10);
		objHealth.currentHealth -= damage;
		objHealth.UpdateScale();
		
		if (objHealth.currentHealth <= 0) {
			other.gameObject.GetComponent<PickUpFood>().Drop();
			//AudioSource.PlayClipAtPoint(, Camera.main.transform.position);
			Destroy(other.gameObject.transform.parent.gameObject);
			xp.GiveExperienceKill(Base.gameObject.GetComponent<Description>().name, 10);
		}
		
		Instantiate(HitEffect, transform.position, transform.rotation);
		Destroy(gameObject);
	}

	void HitTerrain(GameObject other) {
		Instantiate(MissEffect, transform.position, transform.rotation);
		Destroy(gameObject);
	}

	float CalculateDamage() {

		float damage = Module.Damage;

		AttackModifier am = Base.gameObject.GetComponent<AttackModifier>();
		
		if(am != null)
		{
			damage = am.ModifyDamage(damage);
		}

		return damage;
	}
}
