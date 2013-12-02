using UnityEngine;
using System.Collections.Generic;

public class UavBase : BaseProperties {

    public GameObject DroneTemplate;

    [HideInInspector]
    public List<Uav> Drones;

    private List<GameObject> targets;

    private List<GameObject> droneTargets;

	// Use this for initialization
	void Start () {
        targets = new List<GameObject>();

        droneTargets = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {

        foreach (Uav uav in Drones)
        {
            if (uav.Target == null)
            {
                if (targets.Count > 0)
                {
                    targets.Sort((one, two) =>
                        (int)(Vector3.Distance(transform.position, one.transform.position) -
                            Vector3.Distance(transform.position, two.transform.position))
                    );

                    uav.Target = targets.Find(tgt => !droneTargets.Contains(tgt));

                    if (uav.Target != null)
                    {
                        droneTargets.Add(uav.Target);
                    }
                }

                if (uav.Target == null)
                {
                    uav.TargetPosition = transform.position;
                }
            }
        }
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

    public override void SpawnModule(GameObject go)
    {
        Drones = new List<Uav>();

        for (int x = 0; x < 3; x++)
        {
            GameObject drone = (GameObject)Instantiate(go, transform.position + Vector3.up * 5, Quaternion.identity);
            Drones.Add(drone.GetComponent<Uav>());
        }
    }
}
