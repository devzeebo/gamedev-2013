using UnityEngine;
using System.Collections;

public class LoseLevel : MonoBehaviour {

	private FoodPile Food;

	// Use this for initialization
	void Start () {
		Food = GameObject.Find("Food Pile").GetComponent<FoodPile>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Food.FoodObjects.Count == 0) {
			Debug.Log("Lose!");
		}
	}
}
