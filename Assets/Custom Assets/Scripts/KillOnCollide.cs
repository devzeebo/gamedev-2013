using UnityEngine;
using System.Collections;

public class KillOnCollide : MonoBehaviour {
	
	public LookAtEnemy tower;
	public GameObject dust;

	void Start () {
	}
	
	void Update () {
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
            Health objHealth = other.gameObject.GetComponent<Health>();
            objHealth.currentHealth -= 15;
			
			objHealth.UpdateScale();

            if (objHealth.currentHealth <= 0) {
                Destroy(other.gameObject);
                tower.RemoveTracking();
            }
			
			Instantiate(dust, transform.position, transform.rotation);
            Destroy(gameObject);
		}
		else if (other.tag == "Terrain")
		{
			Instantiate(dust, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}