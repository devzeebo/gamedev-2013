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
			GUI.Box (new Rect (Screen.width / 2, Screen.height / 2,100,90), entry.Key + " " + entry.Value);
            //GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 100,100), entry.Key + " " + entry.Value);
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

		Debug.Log ("Experience " + type + " " + currentExperience [type]);
    }
    
    public void GiveExperienceKill(string type, float enemyExperience) {
        
		if (!currentExperience.ContainsKey(type)) {
            currentExperience[type] = 0;
        }
		currentExperience[type] += enemyExperience * KillExperienceBounty;
    }
}