using UnityEngine;
using System.Collections;

public class BuildBase : OnTouchObject {
	
	public GameObject baseObj;
	
	public override void OnTouch ()
	{
		base.OnTouch ();
		
		Instantiate(baseObj, CameraController.selectedTile.position, CameraController.selectedTile.rotation);
		Destroy(CameraController.selectedTile.gameObject);
		CameraController.DeleteMenu();
	}
}