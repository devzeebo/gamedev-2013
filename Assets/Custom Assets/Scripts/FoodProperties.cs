using UnityEngine;
using System.Collections;

public class FoodProperties : MonoBehaviour {
	
	[HideInInspector]
	public Transform heldBy;
	
	void Start () {
		heldBy = null;
	}
	
	void Update () {
	}
}