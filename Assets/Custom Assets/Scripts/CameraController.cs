﻿using UnityEngine;
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
	
	InputHandler inputHandler;
	
	void Start () {
		menuOpen = false;
		inputHandler = new InputHandler();
	}
	
	void Update () {
		Debug.ClearDeveloperConsole();
		
		inputHandler.handleInput();
		
		if (inputHandler.Events.Count > 0) {
			Debug.Log (inputHandler.Events[0].active);
			Debug.Log (inputHandler.Events[0].position);
			Debug.Log (inputHandler.Events[0].deltaPosition);
			Debug.Log (inputHandler.Events[0].phase);
		}
		
		foreach (InputEvent e in inputHandler.Events)
		{
			Vector3 touchPoint = Camera.main.ScreenToWorldPoint(new Vector3(e.position.x, e.position.y, 40));
			Debug.DrawLine(Camera.main.transform.position, touchPoint, Color.red);
			
			if (menuOpen)
			{
				//if (touch.phase == TouchPhase.Moved)
				//	DeleteMenu();
				if (e.phase == TouchPhase.Ended)
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
				if (e.phase == TouchPhase.Moved && e.deltaPosition.magnitude > 0.5f)
				{
					Vector2 touchDeltaPosition = e.deltaPosition;
					Move(touchDeltaPosition);
				}
				if (e.phase == TouchPhase.Ended)
				{
					RaycastHit target;
					if (Physics.Raycast(Camera.main.transform.position, (touchPoint - Camera.main.transform.position).normalized, out target)) {
						
						if (target.transform.tag == "Tile") {
							CreateMenu(target.transform);
						}
						else if (target.transform.tag == "Base") {
							target.transform.gameObject.GetComponent<OnTouchObject>().OnTouch();
						}
					}
				}
			}
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
