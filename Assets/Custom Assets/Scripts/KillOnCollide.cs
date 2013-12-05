using UnityEngine;
using System.Collections;

public class KillOnCollide : MonoBehaviour {
	
	public LookAtEnemy tower;
	public GameObject dust;
	public GameObject hit;
	public AudioClip EnemyDeath;
	public AudioClip EnemyHit;
	public BaseProperties BaseProp;
	
	private Experience xp;  
	

	void Start () {
		xp = GameObject.Find("Global").GetComponent<Experience>();
	}
	
	void Update () {
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
            Health objHealth = other.gameObject.GetComponent<Health>();
            
			float damage = 15;
			
			AttackModifier am = tower.transform.parent.gameObject.GetComponent<AttackModifier>();
			
			if(am != null)
			{
				damage = am.ModifyDamage(damage);
			}
			
			//xp.GiveExperienceHit(BaseProp.type, damage, objHealth.maxHealth, 10);
            objHealth.currentHealth -= damage;
			objHealth.UpdateScale();

            if (objHealth.currentHealth <= 0) {
				other.gameObject.GetComponent<PickUpFood>().Drop();
				AudioSource.PlayClipAtPoint(EnemyDeath, Camera.main.transform.position);
                Destroy(other.gameObject.transform.parent.gameObject);
                tower.RemoveTracking();
				//xp.GiveExperienceKill(BaseProp.type, 10);
            }
			
			Instantiate(hit, transform.position, transform.rotation);
            Destroy(gameObject);
		}
		else if (other.tag == "Terrain")
		{
			Instantiate(dust, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}