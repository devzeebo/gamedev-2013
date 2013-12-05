using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ModuleProperties))]
public class LookAtTarget : MonoBehaviour {

	private ModuleProperties Module;

	void Start() {

		Module = gameObject.GetComponent<ModuleProperties>();
	}
	
	void Update() {

		if (Module.CurrentTarget != null) {
			transform.LookAt(Module.CurrentTarget.transform.position);
		}
	}
}