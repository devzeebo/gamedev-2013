using UnityEngine;
using System.Collections;

public class AcquireEnemy : MonoBehaviour {

	private ModuleProperties Module;

	public void Start() {
		Module = transform.parent.GetComponent<ModuleProperties>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			Module.targets.Add(other.gameObject);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (Module.targets.Contains(other.gameObject))
		{
			Module.targets.Remove(other.gameObject);

			if (Module.CurrentTarget == other.gameObject) {
				Module.CurrentTarget = null;
			}
		}
	}
}
