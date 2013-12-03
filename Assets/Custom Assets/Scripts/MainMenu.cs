using UnityEngine;
using System.Collections;


public class MainMenu : MonoBehaviour {
	
	bool level = false;
	bool isMainMenu = true;
	
	void OnGUI () 
	{	
		
		if(isMainMenu)
		{
			// Make a background box
			GUI.Box(new Rect(Screen.width/2-20,Screen.height/2,100,90), "Fluff Command");
	
			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(Screen.width/2-10,Screen.height/2+30,80,20), "Levels")) 
			{
				level = true;
				isMainMenu = false;
			}
	
			// Make the second button.
			if(GUI.Button(new Rect(Screen.width/2-10,Screen.height/2+60,80,20), "Quit"))  
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
					Application.LoadLevel(1);
				}
				if (GUI.Button(new Rect(Screen.width/2-10,Screen.height/2+60,80,20), "Level 2"))
				{
					print ("This is where I would put level 2.... If I had one");
				}
			}
		}
	}	
}