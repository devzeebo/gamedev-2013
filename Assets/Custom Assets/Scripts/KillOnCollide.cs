using UnityEngine;
using System.Collections;

public class KillOnCollide : MonoBehaviour {
	
	public LookAtEnemy tower;
	public GameObject dust;
	public GameObject hit;

	void Start () {
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
            objHealth.currentHealth -= damage;
			objHealth.UpdateScale();

            if (objHealth.currentHealth <= 0) {
				other.gameObject.GetComponent<PickUpFood>().Drop();
                Destroy(other.gameObject.transform.parent.gameObject);
                tower.RemoveTracking();
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