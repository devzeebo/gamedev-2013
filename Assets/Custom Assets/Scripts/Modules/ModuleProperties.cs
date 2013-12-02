using UnityEngine;
using System.Collections.Generic;

public class ModuleProperties : MonoBehaviour {

    private SphereCollider range;

    public float Damage;

    public float AttackSpeed;

    private List<GameObject> targets;

    public TargetingScript TargetingScript;

	// Use this for initialization
	void Start () {
        range = gameObject.GetComponentInChildren<SphereCollider>();

        targets = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            targets.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (targets.Contains(other.gameObject))
        {
            targets.Remove(other.gameObject);
        }
    }
}
