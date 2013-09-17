using UnityEngine;
using System.Collections;

public class BuildModule : OnTouchObject {
	
	public GameObject moduleObj;
	
	public override void OnTouch ()
	{
		base.OnTouch ();
		
		Instantiate(moduleObj, CameraController.selectedTile.position + moduleObj.transform.position, CameraController.selectedTile.rotation);
		CameraController.DeleteMenu();
	}
}