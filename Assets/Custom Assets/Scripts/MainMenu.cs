﻿using UnityEngine;
using System.Collections;


public class MainMenu : MonoBehaviour {
	
	public GUIStyle background;
	
	bool level = false;
	bool isMainMenu = true;

	void Start(){
	}

	
	void OnGUI () 
	{	
		// Make a background box
		GUI.Box(new Rect(0,0,Screen.width,Screen.height)," ", background);

		if(isMainMenu)
		{
	
			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(Screen.width/3,Screen.height/5,Screen.width/3,Screen.height/4), "Play")) 
			{
				Application.LoadLevel("Level");
				/*level = true;
				isMainMenu = false;*/
			}
	
			// Make the second button.
			if(GUI.Button(new Rect(Screen.width/3,Screen.height/2,Screen.width/3,Screen.height/4), "Quit"))  
			{
				Application.Quit();
				isMainMenu = false;
			}

		}
		else
		{
			if(level)
			{ 	
				if (GUI.Button(new Rect(Screen.width/3,Screen.height/5,Screen.width/3,Screen.height/4), "Level 1"))
				{
					Application.LoadLevel("Level");
				}
				if(GUI.Button(new Rect(Screen.width/3,Screen.height/2,Screen.width/3,Screen.height/4), "Level 2")) 
				{
					print ("This is where I would put level 2.... If I had one");
				}
			}
		}
	}	
}