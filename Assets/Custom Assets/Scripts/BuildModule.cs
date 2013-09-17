using UnityEngine;
using System.Collections;

public class BuildModule : OnTouchObject {
	
	public GameObject moduleObj;
	
	public override void OnTouch()
	{
		base.OnTouch();
		
		GameObject module = (GameObject)Instantiate(moduleObj, CameraController.createdMenu.Reference.transform.position + moduleObj.transform.position, CameraController.createdMenu.Reference.transform.rotation);
        CameraController.createdMenu.Reference.GetComponent<BaseProperties>().module = module;
	}
}