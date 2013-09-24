using UnityEngine;
using System.Collections;

public class PickUpFood : MonoBehaviour {
	
	[HideInInspector]
	public Transform food;
	
	void Start () {
		food = null;
	}
	
	void Update () {
	}
	
	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Food")
		{
			if (food == null && other.transform.GetComponent<FoodProperties>().heldBy == null)
			{
				food = other.transform;
				other.transform.GetComponent<FoodProperties>().heldBy = transform;
				transform.parent.GetComponent<PathMovement>().InvertMovement();
				
				Vector3 position = transform.position;
				position.x += 2;
				food.position = position;
				food.parent = transform;
				food.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			}
		}
	}
	
	public void Drop()
	{
		if (food != null)
		{
			food.rigidbody.constraints = RigidbodyConstraints.None;
			food.parent = null;
			food = null;
		}
	}
}