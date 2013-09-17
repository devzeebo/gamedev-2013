using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

    [HideInInspector]
    public static Menu createdMenu;
    public static Menu ActiveMenu
    {
        get { return createdMenu; }
        set
        {
            createdMenu = value;
            Debug.Log("Created New Menu: " + value);
        }
    }
	
	public float speed;
	
	[HideInInspector]
	public static bool menuOpen;
	
	InputHandler inputHandler;
	
	void Start () {
		menuOpen = false;
		inputHandler = new InputHandler();
	}
	
	void Update () {
		
		inputHandler.handleInput();
		
		foreach (InputEvent e in inputHandler.Events)
		{
			Vector3 touchPoint = Camera.main.ScreenToWorldPoint(new Vector3(e.position.x, e.position.y, 40));
			Debug.DrawLine(Camera.main.transform.position, touchPoint, Color.red);
			
			if (createdMenu != null)
			{
                if (e.phase == TouchPhase.Ended)
                {
                    GameObject o = GetTouchedObject(touchPoint);
                    if (o.tag == "Button")
                    {
                        OnTouchObject touchEvent = o.GetComponent<OnTouchObject>();
                        touchEvent.OnTouch();
                    }

                    DeleteMenu();
                }
			}
			else
			{
				if (e.phase == TouchPhase.Moved && e.deltaPosition.magnitude > 0.5f)
				{
					Vector2 touchDeltaPosition = e.deltaPosition;
					Move(touchDeltaPosition);
				}
				if (e.phase == TouchPhase.Ended)
				{
                    GameObject o = GetTouchedObject(touchPoint);
                    if (o != null && o.GetComponent<OnTouchObject>() != null)
                    {
                        o.GetComponent<OnTouchObject>().OnTouch();
                    }
				}
			}
		}
	}
	
	void Move(Vector2 push)
	{
		transform.Translate(-push.x * speed, -push.y * speed, 0);
	}

    GameObject GetTouchedObject(Vector3 vector)
    {
        RaycastHit target;
        if (Physics.Raycast(Camera.main.transform.position, (vector - Camera.main.transform.position).normalized, out target))
        {
            return target.transform.gameObject;
        }

        return null;
    }
	
	public static void DeleteMenu()
	{
		Destroy(createdMenu.gameObject);
        createdMenu = null;
	}
}
