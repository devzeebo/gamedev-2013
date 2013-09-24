using UnityEngine;
using System.Collections;

public class AcquireEnemy : MonoBehaviour {
	
	LookAtEnemy ModuleAttack;
	
	public void Start()
	{
		ModuleAttack = transform.parent.gameObject.GetComponent<LookAtEnemy>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Trigger Enter");
		if (other.tag == "Enemy")
		{
			if (ModuleAttack.tracking == null)
				ModuleAttack.tracking = other.gameObject;
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Enemy")
		{
			if (ModuleAttack.tracking == null)
				ModuleAttack.tracking = other.gameObject;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == ModuleAttack.tracking)
			ModuleAttack.tracking = null;
	}
}
