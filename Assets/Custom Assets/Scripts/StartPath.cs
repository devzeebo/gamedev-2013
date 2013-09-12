using UnityEngine;
using System.Collections;

public class StartPath : MonoBehaviour {

	public GameObject path;
	
	void Start () {
		GetComponent<FollowPath>().SetFollowingPath(path);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
