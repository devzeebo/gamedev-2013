using UnityEngine;
using System.Collections;


public class MainMenu : MonoBehaviour {

	public Texture2D myTexture;
	
	bool level = false;
	bool isMainMenu = true;
	
	void OnGUI () 
	{	
		// Make a background box
		GUI.Box(new Rect(0,0,Screen.width,Screen.height), "");

		if(isMainMenu)
		{
	
			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(0,0,Screen.width/3,Screen.height/3), "Levels")) 
			{
				level = true;
				isMainMenu = false;
			}
	
			// Make the second button.
			if(GUI.Button(new Rect(0,0,Screen.width/3,Screen.height/3), "Quit"))  
			{
				Application.Quit();
				isMainMenu = false;
			}

		}
		else
		{
			if(level)
			{ 	
				if (GUI.Button(new Rect(Screen.width/2-10,Screen.height/2+30,80,20), "Levels 1"))
				{
					Application.LoadLevel("Level");
				}
				if (GUI.Button(new Rect(Screen.width/2-10,Screen.height/2+60,80,20), "Level 2"))
				{
					print ("This is where I would put level 2.... If I had one");
				}
			}
		}
	}	
}