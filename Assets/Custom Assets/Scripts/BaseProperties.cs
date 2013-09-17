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
		base.OnTouch ();
		
		if (module == null)
		{
			//Debug.Log("Tap Base");
			CreateMenu(transform);
		}
	}
	
	void CreateMenu(Transform tile)
	{
		CameraController.menuOpen = true;
		CameraController.createdMenu = (GameObject)Instantiate(menu, tile.position, tile.rotation);
		CameraController.selectedTile = transform;
	}
}