using UnityEngine;
using System.Collections.Generic;

public class Experience : MonoBehaviour {
    
    // from tower name to exp
    // BaseProperties needs a string 'type'
    public Dictionary<string, float> currentExperience;

    public float KillExperienceBounty;
    
    // Use this for initialization
    void Start () {
    
        // load from save file
    
		currentExperience = new Dictionary<string, float>();
        DontDestroyOnLoad(gameObject);
    }
	
	void OnGUI() {
    	
		//GUI.Box (new Rect (Screen.width / 2, Screen.height / 2,100,90), "Loader Menu");
        foreach(KeyValuePair<string, float> entry in currentExperience)
        {
			if(entry.Key == "Stump")
			{
				GUI.Box (new Rect (0, 0,100, 30 ), entry.Key + " " + entry.Value);
			}
			else
			{
				GUI.Box (new Rect (0, 30,100, 30 ), entry.Key + " " + entry.Value);
			}

        }
    }
    
    // Update is called once per frame
    void Update () {
        
    }
    
    public void GiveExperienceHit(string type, float damage, float enemyHealth, float enemyExperience) {

		if (!currentExperience.ContainsKey(type)) {
            currentExperience[type] = 0;
        }
        currentExperience[type] += damage / enemyHealth * enemyExperience;
    }
    
    public void GiveExperienceKill(string type, float enemyExperience) {
        
		if (!currentExperience.ContainsKey(type)) {
            currentExperience[type] = 0;
        }
		currentExperience[type] += enemyExperience * KillExperienceBounty;
    }
}