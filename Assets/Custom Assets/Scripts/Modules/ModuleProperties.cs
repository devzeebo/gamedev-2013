using UnityEngine;
using System.Collections.Generic;

public class ModuleProperties : MonoBehaviour {

    private SphereCollider range;

    public float Damage;

    public float AttackSpeed;

    internal List<GameObject> targets;

	[HideInInspector]
	public GameObject CurrentTarget;

    public TargetingScript TargetingScript;

	[HideInInspector]
	public BaseProperties Base;

	// Use this for initialization
	void Start () {
        range = gameObject.GetComponentInChildren<SphereCollider>();

        targets = new List<GameObject>();

		Base = transform.parent.gameObject.GetComponent<BaseProperties>();
	}
	
	// Update is called once per frame
	void Update () {

		if (CurrentTarget == null && targets.Count > 0) {
			CurrentTarget = TargetingScript.GetNextEnemy(targets);
		}
	}
}
