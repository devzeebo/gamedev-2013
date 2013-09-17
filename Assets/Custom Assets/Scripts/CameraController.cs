using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {
	
	public GameObject menu;
	[HideInInspector]
	public static GameObject createdMenu;
	
	public float speed;
	
	[HideInInspector]
	public static bool menuOpen;
	
	[HideInInspector]
	public static Transform selectedTile;
	
	List<int> fingerIds;
	
	void Start () {
		menuOpen = false;
		fingerIds = new List<int>();
	}
	
	void Update () {
		if (Input.touchCount > 0)
		{
			foreach (Touch touch in Input.touches)
			{
				Vector3 touchPoint = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 40));
				Debug.DrawLine(Camera.main.transform.position, touchPoint, Color.red);
				
				if (menuOpen)
				{
					//if (touch.phase == TouchPhase.Moved)
					//	DeleteMenu();
					if (touch.phase == TouchPhase.Ended)
					{
						RaycastHit target;
						if (Physics.Raycast(Camera.main.transform.position, (touchPoint - Camera.main.transform.position).normalized, out target))
						{
							//Debug.Log("Hit Object");
							if (target.transform.gameObject.GetComponent<OnTouchObject>() != null)
							{
								//Debug.Log("Object is a 3D button");
								target.transform.gameObject.GetComponent<OnTouchObject>().OnTouch();
							}
						}
						DeleteMenu();
					}
				}
				else
				{
					if (touch.phase == TouchPhase.Moved && touch.deltaPosition.magnitude > 0.5f)
					{
						Vector2 touchDeltaPosition = touch.deltaPosition;
						Move(touchDeltaPosition);
						fingerIds.Add(touch.fingerId);
					}
					if (touch.phase == TouchPhase.Ended)
					{
						if (fingerIds.Contains(touch.fingerId))
						{
							fingerIds.Remove(touch.fingerId);
						}
						else
						{
							RaycastHit target;
							if (Physics.Raycast(Camera.main.transform.position, (touchPoint - Camera.main.transform.position).normalized, out target))
							{
								if (target.transform.tag == "Tile")
								{
									CreateMenu(target.transform);
								}
								else if (target.transform.tag == "Base")
								{
									target.transform.gameObject.GetComponent<OnTouchObject>().OnTouch();
								}
							}
						}
					}
				}
			}
		}
		else
		{
			fingerIds.Clear();
		}
	}
	
	void Move(Vector2 push)
	{
		transform.Translate(-push.x * speed, -push.y * speed, 0);
	}
	
	void CreateMenu(Transform tile)
	{
		menuOpen = true;
		selectedTile = tile;
		
		createdMenu = (GameObject)Instantiate(menu, tile.position, tile.rotation);
	}
	
	public static void DeleteMenu()
	{
		menuOpen = false;
		Destroy(createdMenu);
	}
}
