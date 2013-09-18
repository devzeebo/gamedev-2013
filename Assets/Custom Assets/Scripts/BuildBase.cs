using UnityEngine;
using System.Collections;

public class BuildBase : OnTouchObject {

    public int cost;

	public GameObject baseObj;
	
	public override void OnTouch()
	{
		base.OnTouch();

        if (GameObject.Find("MoneyCounter").GetComponent<Currency>().Charge(cost))
        {
            // Create the Base object
            GameObject temp = (GameObject)Instantiate(baseObj, CameraController.ActiveMenu.Reference.transform.position, CameraController.ActiveMenu.Reference.transform.rotation);

            Destroy(CameraController.ActiveMenu.Reference);
        }
	}
}