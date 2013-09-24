using UnityEngine;
using System.Collections;

public class BuildModule : OnTouchObject {

    public int cost;

	public GameObject moduleObj;
	
	public override void OnTouch()
	{
		base.OnTouch();

        if (GameObject.Find("MoneyCounter").GetComponent<Currency>().Charge(cost))
        {
            GameObject module = (GameObject)Instantiate(moduleObj, CameraController.createdMenu.Reference.transform.position + moduleObj.transform.position, CameraController.createdMenu.Reference.transform.rotation);
            module.transform.parent = CameraController.createdMenu.Reference.transform;
			CameraController.createdMenu.Reference.GetComponent<BaseProperties>().module = module;
        }
	}
}