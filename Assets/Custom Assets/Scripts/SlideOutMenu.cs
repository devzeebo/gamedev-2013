using UnityEngine;
using System.Collections;

public class SlideOutMenu : MonoBehaviour {
	
	public UIAnchor anchor;
	
	Vector2 startPress;
	Vector2 endPress;
	
	bool menuOpen;
	
	void Start () {
		startPress = Vector2.zero;
		endPress = Vector2.zero;
		
		menuOpen = false;
	}
	
	void Update () {
	}
	
	void OnPress(bool isDown)
	{
		if (isDown)
			setMenu(!menuOpen);
	}
	
	void setMenu(bool on)
	{
		if (on)
		{
			anchor.relativeOffset.x = 0.09f;
			
			menuOpen = true;
		}
		else
		{
			anchor.relativeOffset.x = -0.065f;
			
			menuOpen = false;
		}
		
		startPress = Vector2.zero;
		endPress = Vector2.zero;
	}
}
