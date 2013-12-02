using UnityEngine;
using System.Collections;

public class BaseProperties : OnTouchObject {
	
	public GameObject menu;

    public Vector3 SpawnPosition;

    [HideInInspector]
    public GameObject Module
    {
        get
        {
            return module;
        }

        set
        {
            module = value;
            if (module != null)
            {
                module.transform.parent = gameObject.transform;
            }
        }
    }
    GameObject module;
	
	void Start () {
		module = null;
	}
	
	void Update () {
	}

    public virtual void SpawnModule(GameObject obj)
    {
        Module = (GameObject)Instantiate(obj,
            transform.position + SpawnPosition,
            Quaternion.identity);
    }
}