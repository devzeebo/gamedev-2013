using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public GameObject MissEffect;

	public GameObject HitEffect;

	public AudioClip EnemyHit;

	public ModuleProperties Module;

	public BaseProperties Base;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "enemy") {
			HitEnemy(other.gameObject);
		}
		if (other.tag == "Terrain") {
			HitTerrain(other.gameObject);
		}
	}

	void HitEnemy(GameObject other) {

	}

	void HitTerrain(GameObject other) {

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
