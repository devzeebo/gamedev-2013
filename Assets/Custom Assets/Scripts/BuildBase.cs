using UnityEngine;
using System.Collections;

public class BuildBase : OnTouchObject {
	
	public GameObject baseObj;
	
	public override void OnTouch()
	{
		base.OnTouch();

        // Create the Base object
        GameObject temp = (GameObject)Instantiate(baseObj, CameraController.ActiveMenu.Reference.transform.position, CameraController.ActiveMenu.Reference.transform.rotation);

        Destroy(CameraController.ActiveMenu.Reference);
	}
}