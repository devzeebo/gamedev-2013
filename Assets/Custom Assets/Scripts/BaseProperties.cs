using UnityEngine;
using System.Collections;

public class BaseProperties : OnTouchObject {
	
	public GameObject menu;
	
	[HideInInspector]
	public GameObject module;
	
	void Start () {
		module = null;
	}
	
	void Update () {
	}
	
	public override void OnTouch ()
	{
		base.OnTouch();
		
		if (module == null)
		{
            // create the menu object
            GameObject temp = (GameObject)Instantiate(menu, transform.position, transform.rotation);
            temp.AddComponent<Menu>();
            temp.GetComponent<Menu>().Reference = gameObject;

            CameraController.createdMenu = temp.GetComponent<Menu>();
		}
	}
}